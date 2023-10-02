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

            List<bp_data> bp_Datas;
            bp_Datas= db.Get_Data("jgjghj");

            dg_display.Rows.Clear();
            dg_display.Rows.Add(bp_Datas.Count);
            for(int i = 0; i < bp_Datas.Count; i++)
            {
                dg_display[0, i].Value=bp_Datas[i].Record_No.ToString();
                dg_display[1, i].Value=bp_Datas[i].User_ID.ToString();
                dg_display[2, i].Value=bp_Datas[i].DateTime.ToString();
                dg_display[3, i].Value=bp_Datas[i].SIS.ToString();
                dg_display[4, i].Value=bp_Datas[i].DIA.ToString();
                dg_display[5, i].Value=bp_Datas[i].PUL.ToString();
            }

            lbl_record_total.Text="Total Record Count="+bp_Datas.Count.ToString();

        }
    }
}
