using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Plugin_Pargorn
{
	/// <summary>
	/// Summary description for ctlMain.
	/// </summary>
	public class ctlMain : System.Windows.Forms.UserControl
    {
        private Button button1;
        private TextBox textBox1;
        private Label label1;
        private Label label2;

        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

		public ctlMain()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call

		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.button1.Location = new System.Drawing.Point(131, 126);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 34);
            this.button1.TabIndex = 0;
            this.button1.Text = "คำนวน";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.on_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.textBox1.Location = new System.Drawing.Point(102, 79);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(152, 26);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(14, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "กรุณาใส่ วัน/เดือน/ปี";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(60, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "พ.ศ.";
            // 
            // ctlMain
            // 
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Name = "ctlMain";
            this.Size = new System.Drawing.Size(357, 236);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
        static string zodiac(int year)
        {
            string[] year_zodiac = {
                "ปีมะเส็ง,ปีงูเล็ก", "ปีมะเมีย,ปีม้า", "ปีมะแม,ปีแพะ", "ปีวอก,ปีลิง", "ปีระกา,ปีไก่", "ปีจอ,ปีหมา",
                "ปีกุน,ปีหมู", "ปีชวด,ปีหนู", "ปีฉลู,ปีวัว", "ปีขาล,ปีเสือ", "ปีเถาะ,ปีกระต่าย", "ปีมะโรง,ปีงูใหญ่"
            };
            return year_zodiac[year % 12];
        }
        private void on_Click(object sender, EventArgs e)
        {
            DateTime date_now = DateTime.Now;
            DateTime date_input;
            DateTime.TryParseExact(textBox1.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out date_input);

            if (!DateTime.TryParseExact(textBox1.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out date_input))
                MessageBox.Show("คุณกรอก วัน/เดือน/ปี เกิดไม่ถูกต้อง !", "ล้มเหลว", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                int day, month, year;

                int DaysInBdayMonth = DateTime.DaysInMonth(date_input.Year, date_input.Month);
                int DaysRemain = date_now.Day + (DaysInBdayMonth - date_input.Day);

                if (date_now.Month > date_input.Month)
                {
                    year = (date_now.Year + 543) - date_input.Year;
                    month = date_now.Month - (date_input.Month + 1) + Math.Abs(DaysRemain / DaysInBdayMonth);
                    day = (DaysRemain % DaysInBdayMonth + DaysInBdayMonth) % DaysInBdayMonth;
                }
                else if (date_now.Month == date_input.Month)
                {
                    if (date_now.Day >= date_input.Day)
                    {
                        year = (date_now.Year + 543) - date_input.Year;
                        month = 0;
                        day = date_now.Day - date_input.Day;
                    }
                    else
                    {
                        year = ((date_now.Year + 543) - 1) - date_input.Year;
                        month = 11;
                        day = DateTime.DaysInMonth(date_input.Year, date_input.Month) - (date_input.Day - date_now.Day);
                    }
                }
                else
                {
                    year = ((date_now.Year + 543) - 1) - date_input.Year;
                    month = date_now.Month + (11 - date_input.Month) + Math.Abs(DaysRemain / DaysInBdayMonth);
                    day = (DaysRemain % DaysInBdayMonth + DaysInBdayMonth) % DaysInBdayMonth;
                }

                MessageBox.Show("อายุของคุณ " + year + " ปี " + month + " เดือน " + day + " วัน " + "\n" +
                                "ปีนักษัตร : " + zodiac(date_input.Year), "ผลลัพท์", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
    #endregion
}
