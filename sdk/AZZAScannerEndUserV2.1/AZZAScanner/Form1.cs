using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;
using Microsoft.VisualBasic;
using AZZAScannerDllV2;

namespace AZZAScanner
{
    public partial class Form1 : Form
    {
        private int g_cardType = AzzadllClass.CARDTYPE_UNKOWN;
        private string g_cardName;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnDocCCCD_Click(object sender, EventArgs e)
        {


            hd = AzzadllClass.AZZAV5_open();


            //showlog();
            if ((int)hd >= 0)
            {


                StringBuilder sr = new StringBuilder();
               

                this.textBox_1.Text = "";

                logInf(true, "Open", "Open");

                Azza_Scan();

                AZZA_ReadCard();

                AZZA_pass_activeBykey_Click();

                AZZA_pass_readDigitalText();

                AZZA_pass_readDigitalImage();

                AZZA_reject();

            }
            else
            {
                logInf(false, "Open", "Open");
            }
        }

        #region

        public string GetTimeStr()
        {
            string tempTimeStr = DateTime.Now.Hour.ToString().PadLeft(2, '0') + ":" + DateTime.Now.Minute.ToString().PadLeft(2, '0') + ":" + DateTime.Now.Second.ToString().PadLeft(2, '0'); /* 以年-月-日时分秒的格式命名文件 */
            return tempTimeStr;
        }

        void log_AppendText(string s)
        {
            tb_log.AppendText(GetTimeStr() + " " + s);
        }

        private void str2bytes(string str, ref byte[] apdu, ref int len)
        {
            char[] chs = { ' ' };
            string[] res = str.Split(chs, options: StringSplitOptions.RemoveEmptyEntries); //Split the string into multiple groups by space.
            int datalen = res.Length;
            for (int i = 0; i < datalen; i++)                                               //Convert the string into a byte array.
            {
                apdu[i] = (byte)Convert.ToInt32(res[i], 16);

            }
            len = datalen;
        }

        private void str2bytes_nospace(string str, ref byte[] apdu, ref int len)
        {
            int datalen = str.Length / 2;
            ;
            for (int i = 0; i < datalen; i++)                                               //Convert the string to a byte array.
            {
                apdu[i] = (byte)Convert.ToInt32(str.Substring(i * 2, 2), 16);

            }
            len = datalen;
        }


        private void bytes2str(ref byte[] data, int len, StringBuilder str)
        {
            str.Clear();
            //StringBuilder builder = new StringBuilder();                    //Convert the byte array to a string and display it
            for (int i = 0; i < len; i++)
            {
                str.Append(string.Format("{0:X2} ", data[i]));
            }
        }

        private char to_str10(int x)
        {
            if (x == 1)
            {
                return '1';
            }
            else
            {
                return '0';
            }
        }

        private IntPtr hd = new IntPtr(-1);

        private bool is_not_open()
        {
            if ((int)hd < 0)
            {
               
                    MessageBox.Show("Please open the device first !", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
                return true;
            }
            return false;
        }

        private void logInf(bool statue, string strEnglish, string strChinese)
        {
            if (statue == false)
            {
                strEnglish = strEnglish + " fail!";
            }

           
            log_AppendText(strEnglish + "\r\n");
            if (statue == false)
            {
                MessageBox.Show(strEnglish, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void getOtherTextAndShow() //Retrieve and display recognized text.
        {
            // if (is_not_open()) return;

            tb_OCRtext.Text = "";
            byte[] data = new byte[256];
            int len = AzzadllClass.S2V5_IMG_getBytes_ocr(hd, 1, ref data[0]); //Retrieve text 1
            if (len > 0)
            {
                string text1 = Encoding.UTF8.GetString(data, 0, len);
                tb_OCRtext.Text += "text1: " + text1 + "\r\n";
                tb_pass_MRZcode.Text = text1;
            }

            //StringBuilder text2 = new StringBuilder(512);
            len = AzzadllClass.S2V5_IMG_getBytes_ocr(hd, 2, ref data[0]); //Retrieve text 2
            if (len > 0)
            {
                string text2 = Encoding.UTF8.GetString(data, 0, len);
                tb_OCRtext.Text += "text2: " + text2 + "\r\n";
            }

            len = AzzadllClass.S2V5_IMG_getBytes_ocr(hd, 3, ref data[0]); //Retrieve text 3
            if (len > 0)
            {

                string text3 = Encoding.UTF8.GetString(data, 0, len);
                tb_OCRtext.Text += "text3: " + text3.ToString() + "\r\n";
            }

            len = AzzadllClass.S2V5_IMG_getBytes_ocr(hd, 4, ref data[0]); //Retrieve text 4
            if (len > 0)
            {
                string text4 = Encoding.UTF8.GetString(data, 0, len);
                tb_OCRtext.Text += "text4: " + text4 + "\r\n";
            }

            len = AzzadllClass.S2V5_IMG_getBytes_ocr(hd, 5, ref data[0]); //Retrieve text 5
            if (len > 0)
            {
                string text5 = Encoding.UTF8.GetString(data, 0, len);
                tb_OCRtext.Text += "text5: " + text5 + "\r\n";
            }

            len = AzzadllClass.S2V5_IMG_getBytes_ocr(hd, 6, ref data[0]); //Retrieve text 5
            if (len > 0)
            {
                string text6 = Encoding.UTF8.GetString(data, 0, len);
                tb_OCRtext.Text += "text6: " + text6 + "\r\n";
            }

            len = AzzadllClass.S2V5_IMG_getBytes_ocr(hd, 7, ref data[0]); //Retrieve text 5
            if (len > 0)
            {
                string text7 = Encoding.UTF8.GetString(data, 0, len);
                tb_OCRtext.Text += "text7: " + text7 + "\r\n";
            }
        }

        private void getOtherImgAndShow()  //Retrieve and display screenshot image
        {
            int ret;
            string Img1Path = @"subImg1.bmp";
            ret = AzzadllClass.S2V5_IMG_savePhoto_cut(hd, 1, Img1Path);  //Retrieve screenshot 1
            if (ret == 0)
            {
                try
                {
                    FileStream pFileStream = new FileStream(Img1Path, FileMode.Open, FileAccess.Read);
                    pb_subImage1.Image = Image.FromStream(pFileStream);
                    pFileStream.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            string Img2Path = @"subImg2.bmp";
            ret = AzzadllClass.S2V5_IMG_savePhoto_cut(hd, 2, Img2Path);  //Retrieve screenshot 2
            if (ret == 0)
            {
                try
                {
                    FileStream pFileStream = new FileStream(Img2Path, FileMode.Open, FileAccess.Read);
                    pb_subImage2.Image = Image.FromStream(pFileStream);
                    pFileStream.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            string text1Path = @"textImg1.bmp";
            ret = AzzadllClass.S2V5_IMG_savePhoto_text(hd, 1, text1Path);//Retrieve text screenshot 1
            if (ret == 0)
            {
                try
                {
                    FileStream pFileStream = new FileStream(text1Path, FileMode.Open, FileAccess.Read);
                    pFileStream.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            string text2Path = @"textImg2.bmp";
            ret = AzzadllClass.S2V5_IMG_savePhoto_text(hd, 2, text2Path);//Retrieve text screenshot 2
            if (ret == 0)
            {
                try
                {
                    FileStream pFileStream = new FileStream(text2Path, FileMode.Open, FileAccess.Read);
                    pFileStream.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            string text3Path = @"textImg3.bmp";
            ret = AzzadllClass.S2V5_IMG_savePhoto_text(hd, 3, text3Path);//Retrieve text screenshot 3
            if (ret == 0)
            {
                try
                {
                    FileStream pFileStream = new FileStream(text3Path, FileMode.Open, FileAccess.Read);
                    //pb_OCR3.Image = Image.FromStream(pFileStream);
                    pFileStream.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }


            string text4Path = @"textImg4.bmp";
            ret = AzzadllClass.S2V5_IMG_savePhoto_text(hd, 4, text4Path);//Retrieve text screenshot 4
            if (ret == 0)
            {
                try
                {
                    FileStream pFileStream = new FileStream(text4Path, FileMode.Open, FileAccess.Read);
                    //pb_OCR4.Image = Image.FromStream(pFileStream);
                    pFileStream.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            string text5Path = @"textImg5.bmp";
            ret = AzzadllClass.S2V5_IMG_savePhoto_text(hd, 5, text5Path);//Retrieve text screenshot 5
            if (ret == 0)
            {
                try
                {
                    FileStream pFileStream = new FileStream(text5Path, FileMode.Open, FileAccess.Read);
                    //pb_OCR5.Image = Image.FromStream(pFileStream);
                    pFileStream.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            string text6Path = @"textImg6.bmp";
            ret = AzzadllClass.S2V5_IMG_savePhoto_text(hd, 6, text6Path);//Retrieve text screenshot 6
            if (ret == 0)
            {
                try
                {
                    FileStream pFileStream = new FileStream(text6Path, FileMode.Open, FileAccess.Read);
                    //pb_OCR6.Image = Image.FromStream(pFileStream);
                    pFileStream.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            string text7Path = @"textImg7.bmp";
            ret = AzzadllClass.S2V5_IMG_savePhoto_text(hd, 7, text7Path);//Retrieve text screenshot 7
            if (ret == 0)
            {
                try
                {
                    FileStream pFileStream = new FileStream(text7Path, FileMode.Open, FileAccess.Read);
                    //pb_OCR7.Image = Image.FromStream(pFileStream);
                    pFileStream.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            string text8Path = @"textImg8.bmp";
            ret = AzzadllClass.S2V5_IMG_savePhoto_text(hd, 8, text8Path);//Retrieve text screenshot 8
            if (ret == 0)
            {
                try
                {
                    FileStream pFileStream = new FileStream(text8Path, FileMode.Open, FileAccess.Read);
                    pFileStream.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void MRZtoKey()        //Convert recognized encoding to MRZ code
        {
            tb_pass_MRZkey.Text = "";

            int ret = 0;
            string inf = tb_pass_MRZcode.Text;
            StringBuilder mrz = new StringBuilder();
            //ret = AzzadllClass.S2V5_PASS_string2MRZ(hd, cardType, inf, mrz);
            ret = AzzadllClass.S2V5_PASS_getMRZKey(hd, mrz);
            if (ret != 0)
            {
                MessageBox.Show("生成mrz失败");
                return;
            }

            tb_pass_MRZkey.Text = mrz.ToString();//Display MRZ code
        }

        #endregion

        private void Azza_Scan()
        {


            if (is_not_open()) return;
            tb_cardName.Text = "";

            pb_imgA.Image = null;
            pb_imgB.Image = null;


            pb_subImage1.Image = null;
            pb_subImage2.Image = null;

            tb_OCRtext.Text = "";

            int ret;
            DateTime dateBegin = DateTime.Now;


            ret = AzzadllClass.S2V5_isCardin(hd);                   // Determine if scanning position is detected
            if (ret != 0)
            {
                ret = AzzadllClass.S2V5_MOVE_inside(hd);           // Move the card inside the machine

            }
            ret = AzzadllClass.S2V5_IMG_scan(hd);                  // Scan

            if (ret == -3)
            {
                logInf(false, "Device offline", "Device offline");
                return;
            }
            if (ret < 0)
            {
                logInf(false, "Scan", "Scan");
                return;
            }

            //StringBuilder cardTypeStr = new StringBuilder();
            AzzadllClass.S2V5_IMG_getCardTypeInt(hd, ref g_cardType); // Get the card type number and string

            tb_cardType.Text = g_cardType.ToString();

            byte[] data = new byte[128];
            int len = AzzadllClass.S2V5_IMG_getCardNameBytes(hd, ref data[0]); // Retrieve the card type number and string

            g_cardName = Encoding.UTF8.GetString(data, 0, len);
            tb_cardName.Text = g_cardName;

            string frontImgPath;
            string backImgPath;
            frontImgPath = @"frontImg.bmp";
            backImgPath = @"backImg.bmp";
            AzzadllClass.S2V5_IMG_savePhoto_A(hd, frontImgPath);              // Retrieve the photo of side A

            AzzadllClass.S2V5_IMG_savePhoto_B(hd, backImgPath);               // Retrieve the photo of side B


            frontImgPath = @"frontImg.png";
            backImgPath = @"backImg.png";
            AzzadllClass.S2V5_IMG_savePhoto_A(hd, frontImgPath);              // Retrieve photo from side A

            AzzadllClass.S2V5_IMG_savePhoto_B(hd, backImgPath);             // Retrieve photo from side B



            DateTime dateEnd = DateTime.Now;
            TimeSpan ts1 = new TimeSpan(dateBegin.Ticks);
            TimeSpan ts2 = new TimeSpan(dateEnd.Ticks);
            TimeSpan ts3 = ts1.Subtract(ts2).Duration();
            string inf = (ts3.TotalMilliseconds / 1000).ToString("F2") + "s";
            logInf(true, "Scan " + inf, "Scan " + inf);

            try
            {
                FileStream pFileStream = new FileStream(frontImgPath, FileMode.Open, FileAccess.Read);  
                pb_imgA.Image = Image.FromStream(pFileStream);
                pFileStream.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                FileStream pFileStream = new FileStream(backImgPath, FileMode.Open, FileAccess.Read);  
                pb_imgB.Image = Image.FromStream(pFileStream);
                pFileStream.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (g_cardType != AzzadllClass.CARDTYPE_UNKOWN)
            {
                getOtherImgAndShow();     
                getOtherTextAndShow();    
            }

            //tabControl1.SelectedIndex = 0;
            int dx = 0, dy = 0;
            float mx = 0, my = 0;
            AzzadllClass.S2V5_DEBUG_get_matchValue(hd, ref dx, ref dy, ref mx, ref my);
            inf = ("(" + dx.ToString("D2") + ","
                        + dy.ToString("D2") + ","
                        + mx.ToString("F2") + ","
                        + my.ToString("F2")
                        + ")\r\n");
            tb_log.AppendText("               " + inf);
        }

        private void tb_log_TextChanged(object sender, EventArgs e)
        {

        }

        private void AZZA_ReadCard()
        {
            if (g_cardType >= 200 && g_cardType <= 499) //ICAO Doc 9303 Compliant Cards 
            {
                //tabControl1.SelectedIndex = 1;
                MRZtoKey();
                tb_pass_digitalText.Text = "";
                pb_pass_digitalImage.Image = null;
            }
           
            else
            {                                                //unknown card  
                //tabControl1.SelectedIndex = 3;
                //tb_RF_atr.Text = "";
                //tb_RF_recv.Text = "";
            }

            AzzadllClass.S2V5_MOVE_inside(hd);                  //
        }

        private void bt_pass_generateKey_Click(object sender, EventArgs e)
        {
            if (is_not_open()) return;
            MRZtoKey();
        }


        private byte[] data = new byte[256];
        private string pass_number;             //ID number
        private string pass_name;               //name
        private string pass_chname;             // name
        private string pass_sex;                //sex
        private string pass_birthday;           //birthday
        private string pass_endValidity;        //endValidity
        private string pass_nationality;        //nationality

        private void AZZA_pass_readDigitalText()        
        {
            if (is_not_open()) return;
            tb_pass_digitalText.Text = "";
            DateTime dateBegin = DateTime.Now;
            int len;


            len = AzzadllClass.S2V5_PASS_getBytes(hd, 0, ref data[0]);
            if (len <= 0)      
            {
                logInf(false, "Read digital text", "Read digital text");
                return;
            }
            pass_number = Encoding.UTF8.GetString(data, 0, len);

            len = AzzadllClass.S2V5_PASS_getBytes(hd, 1, ref data[0]);
            pass_name = Encoding.UTF8.GetString(data, 0, len);

            StringBuilder __pass_chname = new StringBuilder(32);
            len = AzzadllClass.S2V5_PASS_getInfo(hd, 2, __pass_chname);
            pass_chname = __pass_chname.ToString();
            len = AzzadllClass.S2V5_PASS_getBytes(hd, 3, ref data[0]);
            pass_sex = Encoding.UTF8.GetString(data, 0, len);
            len = AzzadllClass.S2V5_PASS_getBytes(hd, 4, ref data[0]);
            pass_birthday = Encoding.UTF8.GetString(data, 0, len);
            len = AzzadllClass.S2V5_PASS_getBytes(hd, 5, ref data[0]);
            pass_endValidity = Encoding.UTF8.GetString(data, 0, len);
            len = AzzadllClass.S2V5_PASS_getBytes(hd, 10, ref data[0]);
            pass_nationality = Encoding.UTF8.GetString(data, 0, len);

            string inf = "";
           
            {
                inf += "ID:" + pass_number + "\r\n";
                inf += "name:" + pass_name + "\r\n";
                if (pass_name.Length > 0)
                {
                    inf += "chname:" + pass_chname + "\r\n";
                }
                inf += "sex:" + pass_sex + "\r\n";
                inf += "date of birth:" + pass_birthday + "\r\n";
                inf += "expire date:" + pass_endValidity + "\r\n";

                if (g_cardType == 100 && g_cardName == "Return Home Permit")
                {
                    len = AzzadllClass.S2V5_PASS_getBytes(hd, 6, ref data[0]);
                    string HongKongNumber = Encoding.UTF8.GetString(data, 0, len);
                    inf += "HongKongNumber:" + HongKongNumber + "\r\n";
                }
            }
            tb_pass_digitalText.Text = inf;

            DateTime dateEnd = DateTime.Now;
            TimeSpan ts1 = new TimeSpan(dateBegin.Ticks);
            TimeSpan ts2 = new TimeSpan(dateEnd.Ticks);
            TimeSpan ts3 = ts1.Subtract(ts2).Duration();
            string inf0 = (ts3.TotalMilliseconds / 1000).ToString("F2") + "s";
            logInf(true, "Read digital text " + inf0, "Read digital text" + inf0);

            if (g_cardType == AzzadllClass.CARDTYPE_VIETNAL_ID)
            { //Vietnamese ID card 
                load_Vietnamese_RDOinf_and_show();
            }
            return;
        }

        private string i01_cccd_number;        //(1) CCCD number
        private string i02_full_name;         //(2) Full name, Full name, other name
        private string i03_birth;             //(3) Date, month and year of birth
        private string i04_gender;            //(4) Gender
        private string i05_nationality;       //(5) Nationality
        private string i06_ethnicity;          //(6) Ethnicity
        private string i07_religion;           //(7) Religion
        private string i08_hometown;           //(8) Hometown
        private string i09_address;            //(9) Place of permanent residence registration
        private string i10_identification_characteristics;  //(10) Identification characteristics
        private string i11_issue;              //(11) Date of issue
        private string i12_expiration;         //(12) Expiration date
        private string i13_parent_name;        //(13) Full name of parent, spouse
        private string i14_9digit_id;          //(14) issued 9 - digit ID card number
        private string i15_photos;             //(15) Portrait photos
        private string i16_biometric;          //Features of fingerprint extraction and selection 
        //of two index fingers; backup for iris image, and 
        //other information (expand the application for 
        //other ministries and branches).
        private void load_Vietnamese_RDOinf_and_show()
        {
            int len = 0;
            string returnStr = "";
            string returnStrV = "";
            len = AzzadllClass.S2V5_PASS_getBytes(hd, 101, ref data[0]);
            if (len >= 0)     
            {
                i01_cccd_number = Encoding.UTF8.GetString(data, 0, len);
                returnStr += "01 cccd number: " + i01_cccd_number + "\r\n";
                returnStrV += "1. Số CCCD: " + i01_cccd_number + "\r\n";

                len = AzzadllClass.S2V5_PASS_getBytes(hd, 102, ref data[0]);
                i02_full_name = Encoding.UTF8.GetString(data, 0, len);
                returnStr += "02 full name: " + i02_full_name + "\r\n";
                returnStrV += "2. Họ tên: " + i02_full_name + "\r\n";

                len = AzzadllClass.S2V5_PASS_getBytes(hd, 103, ref data[0]);
                i03_birth = Encoding.UTF8.GetString(data, 0, len);
                returnStr += "03 birth: " + i03_birth + "\r\n";
                returnStrV += "3. Ngày sinh: " + i03_birth + "\r\n";

                len = AzzadllClass.S2V5_PASS_getBytes(hd, 104, ref data[0]);
                i04_gender = Encoding.UTF8.GetString(data, 0, len);
                returnStr += "04 gender: " + i04_gender + "\r\n";
                returnStrV += "4. Giới tính: " + i04_gender + "\r\n";

                len = AzzadllClass.S2V5_PASS_getBytes(hd, 105, ref data[0]);
                i05_nationality = Encoding.UTF8.GetString(data, 0, len);
                returnStr += "05 nationalit: " + i05_nationality + "\r\n";
                returnStrV += "5. Quốc tịch: " + i05_nationality + "\r\n";

                len = AzzadllClass.S2V5_PASS_getBytes(hd, 106, ref data[0]);
                i06_ethnicity = Encoding.UTF8.GetString(data, 0, len);
                returnStr += "06 ethnicity: " + i06_ethnicity + "\r\n";
                returnStrV += "6. Dân tộc: " + i06_ethnicity + "\r\n";

                len = AzzadllClass.S2V5_PASS_getBytes(hd, 107, ref data[0]);
                i07_religion = Encoding.UTF8.GetString(data, 0, len);
                returnStr += "07 religion: " + i07_religion + "\r\n";
                returnStrV += "7. Tôn giáo: " + i07_religion + "\r\n";

                len = AzzadllClass.S2V5_PASS_getBytes(hd, 108, ref data[0]);
                i08_hometown = Encoding.UTF8.GetString(data, 0, len);
                returnStr += "08 hometown: " + i08_hometown + "\r\n";
                returnStrV += "8. Quê quán: " + i08_hometown + "\r\n";

                len = AzzadllClass.S2V5_PASS_getBytes(hd, 109, ref data[0]);
                i09_address = Encoding.UTF8.GetString(data, 0, len);
                returnStr += "09 address: " + i09_address + "\r\n";
                returnStrV += "9. Hộ khẩu TT: " + i09_address + "\r\n";

                len = AzzadllClass.S2V5_PASS_getBytes(hd, 110, ref data[0]);
                i10_identification_characteristics = Encoding.UTF8.GetString(data, 0, len);
                returnStr += "10 identification characteristics: " + i10_identification_characteristics + "\r\n";
                returnStrV += "10. Đặc điểm nhận dạng: " + i10_identification_characteristics + "\r\n";

                len = AzzadllClass.S2V5_PASS_getBytes(hd, 111, ref data[0]);
                i11_issue = Encoding.UTF8.GetString(data, 0, len);
                returnStr += "11 issue: " + i11_issue + "\r\n";
                returnStrV += "11. Ngày cấp CCCD: " + i11_issue + "\r\n";

                len = AzzadllClass.S2V5_PASS_getBytes(hd, 112, ref data[0]);
                i12_expiration = Encoding.UTF8.GetString(data, 0, len);
                returnStr += "12 expiration: " + i12_expiration + "\r\n";
                returnStrV += "12. Ngày hết hạn: " + i12_expiration + "\r\n";

                len = AzzadllClass.S2V5_PASS_getBytes(hd, 113, ref data[0]);
                i13_parent_name = Encoding.UTF8.GetString(data, 0, len);
                returnStr += "13 parent name: " + i13_parent_name + "\r\n";
                returnStrV += "13. Họ tên bố/mẹ: " + i13_parent_name + "\r\n";

                len = AzzadllClass.S2V5_PASS_getBytes(hd, 114, ref data[0]);
                i14_9digit_id = Encoding.UTF8.GetString(data, 0, len);
                //returnStr += "14 digit id: " + i14_9digit_id + "\r\n";
                //returnStrV += "14 digit id: " + i14_9digit_id + "\r\n";

                len = AzzadllClass.S2V5_PASS_getBytes(hd, 115, ref data[0]);
                i15_photos = Encoding.UTF8.GetString(data, 0, len);
                //returnStr += "15 photos: " + i15_photos + "\r\n";
                //returnStrV += "15 photos: " + i15_photos + "\r\n";

                len = AzzadllClass.S2V5_PASS_getBytes(hd, 116, ref data[0]);
                i16_biometric = Encoding.UTF8.GetString(data, 0, len);
                //returnStr += "16 biometric: " + i16_biometric + "\r\n";
                //returnStrV += "16 biometric: " + i16_biometric + "\r\n";
            }
            tb_log.AppendText(returnStr.ToString());

            textBox_1.AppendText(returnStrV.ToString());
            return;
        }


        private void AZZA_pass_activeBykey_Click()   
        {
            if (is_not_open()) return;
            if (tb_pass_MRZkey.Text.Length == 0)
            {
                logInf(false, "need key", "need key");
                return;
            }

            DateTime dateBegin = DateTime.Now;

            int ret;
            ret = AzzadllClass.S2V5_PASS_active(hd, tb_pass_MRZkey.Text);
            DateTime dateEnd = DateTime.Now;
            TimeSpan ts1 = new TimeSpan(dateBegin.Ticks);
            TimeSpan ts2 = new TimeSpan(dateEnd.Ticks);
            TimeSpan ts3 = ts1.Subtract(ts2).Duration();
            string inf = (ts3.TotalMilliseconds / 1000).ToString("F2") + "s";
            logInf(ret == 0, "Active " + inf, "Active" + inf);
        }

        private void AZZA_pass_readDigitalImage()           
        {
            int ret;
            if (is_not_open()) return;
            pb_pass_digitalImage.Image = null;

            DateTime dateBegin = DateTime.Now;
            StringBuilder personInfo = new StringBuilder();
            string picPath = @"Headimg.bmp";
            ret = AzzadllClass.S2V5_PASS_savePicture(hd, picPath);
            if (ret != 0)
            {
                logInf(false, "Read digital image", "Read digital image");
                return;
            }

            try
            {
                FileStream pFileStream = new FileStream(picPath.ToString(), FileMode.Open, FileAccess.Read);
                pb_pass_digitalImage.Image = Image.FromStream(pFileStream);
                pFileStream.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            DateTime dateEnd = DateTime.Now;
            TimeSpan ts1 = new TimeSpan(dateBegin.Ticks);
            TimeSpan ts2 = new TimeSpan(dateEnd.Ticks);
            TimeSpan ts3 = ts1.Subtract(ts2).Duration();
            string inf = (ts3.TotalMilliseconds / 1000).ToString("F2") + "s";
            logInf(true, "Read digital image " + inf, "Read digital image" + inf);
            return;
        }

        private void bt_pass_readDG_Click(object sender, EventArgs e)
        {
          
        }

        private void AZZA_reject()
        {
            if (is_not_open()) return;
            int ret;
            ret = AzzadllClass.S2V5_MOVE_front(hd);
            logInf(ret == 0, "Reject", "Reject");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width = 1020;

    


            string sProductVersion = Application.ProductVersion;
            sProductVersion = sProductVersion.Replace(".", "");



        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                this.Width = 1326;
            }
            else
            {
                this.Width = 1020;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        static private string GiaiMa(string dblSeri)
        {
            string functionReturnValue = null;
            int ii = 0;
            string strTemp = null;
            double dblTemp = 0;
            double dblSoThuNhat = 0;
            double dblSoThuHai = 0;
            try
            {
                strTemp = "";
                for (ii = Strings.Len(dblSeri); ii >= 1; ii += -1)
                {
                    dblSoThuNhat = double.Parse(Strings.Mid(dblSeri, ii, 1));
                    if (ii > 1)
                    {
                        dblSoThuHai = double.Parse(Strings.Mid(dblSeri, ii - 1, 1));
                    }
                    else
                    {
                        dblSoThuHai = double.Parse(Strings.Mid(dblSeri, 4, 1));
                    }

                    if (dblSoThuNhat == 1 | dblSoThuHai == 1)
                    {
                        dblTemp = (dblSoThuNhat + dblSoThuHai) * (dblSoThuNhat + dblSoThuHai) * (dblSoThuNhat + dblSoThuHai);
                    }
                    else
                    {
                        dblTemp = dblSoThuNhat * dblSoThuHai;
                    }

                    if (dblTemp == 0)
                    {
                        dblTemp = (dblSoThuNhat + dblSoThuHai) * (dblSoThuNhat + dblSoThuHai);
                    }
                    dblTemp = double.Parse(Strings.Right(dblTemp.ToString(), 1));
                    if (dblTemp % 2 == 0)
                    {
                        dblTemp = dblTemp + 3;
                    }
                    else
                    {
                        dblTemp = dblTemp + 7;
                    }
                    dblTemp = double.Parse(Strings.Right(dblTemp.ToString(), 1));
                    strTemp = strTemp + dblTemp;
                }
                functionReturnValue = strTemp;
            }
            catch (Exception ex)
            {
                //vt.Msg(ex.Message);
            }
            return functionReturnValue;
        }


    }
}
