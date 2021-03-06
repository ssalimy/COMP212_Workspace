using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _301109706_Mohammadi__Lab01
{
    public partial class PublishNotificationForm : Form
    {
        //Declare an instance variable of the Notification Manager Form.
        StartingForm StartingForm;
        public PublishNotificationForm(StartingForm parent)
        {
            InitializeComponent();
            //Initializing Notification Manager Form as the parent.
            StartingForm = parent;
        }

        private void BtnPublish_Click(object sender, EventArgs e)
        {
            //If textbox is empty, promt user to input content.
            if (string.IsNullOrWhiteSpace(TbxNotiCont.Text))
            { 
                MessageBox.Show("Please input the content.");
            }
            //If textbox is not empty, send message.
            else
            {
                //Passes the user input to the PublishMessage method in the publisher class.
                StringBuilder stringBuilder = new StringBuilder();
                List<string> list = new List<string>();
                //Calls delegate to retrieve phone numbers and emails
                list = (Program.publisher.ReturnRecieversList());
                foreach (string element in list)
                {
                    txtRecievers.Text += element;
                    txtRecievers.Text += (Environment.NewLine);
                }
            }
        }

        private void BtnExit_Click_1(object sender, EventArgs e)
        {
            //Prompt user with message box.
            if (MessageBox.Show("Are you sure you want to close application?", "Close Application", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //Close current form and show FrmNotificationManager form
                this.Hide();
            }
            else
            {
                //Else if no is selected form will stay open.
                this.Activate();
            }
        }
    }
}
