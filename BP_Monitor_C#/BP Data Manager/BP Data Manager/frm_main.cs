using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Tools;

using WebSocketSharp;

namespace BP_Data_Manager
{
    public partial class frm_main : Form
    {
        WordPressDB db = new WordPressDB();
        MSG msg;

        public frm_main()
        {
            InitializeComponent();
            msg=new MSG(lst_msg);
        }

        private void frm_main_Load(object sender, EventArgs e)
        {
            //ws.open("ws://localhost:10017");

            //ws.send("/wp-json/iot/update?SYS=132&DIA=82&PUL=72");
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            if(db.Connected)
            {
                msg.push("Already connected!!!!");
            }
            else
            {
                db.Connect();
                msg.push("Connected With Database OK");
            }       
        }

        private void btn_disconnect_Click(object sender, EventArgs e)
        {
            db.Disconnect();
            msg.push("Database Disconnected");
        }

        private void btn_read_all_Click(object sender, EventArgs e)
        {
            if (!db.Connected)
            { 
                db.Connect();
                msg.push("Connected With Database OK");
            }
            db.Get_Data("xdfsdf");
        }
    }
}
