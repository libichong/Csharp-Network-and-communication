using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace bookshop
{
	/// <summary>
	/// Checkout ��ժҪ˵����
	/// </summary>
	public class Checkout : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Header;
		protected System.Web.UI.WebControls.Label Message;
		protected System.Web.UI.WebControls.DataGrid MyDataGrid;
		protected System.Web.UI.WebControls.Label TotalLbl;
		protected System.Web.UI.WebControls.Button SubmitBtn;
		protected System.Web.UI.WebControls.HyperLink BackHyperLink;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;

		public Checkout() 
		{
			Page.Init += new System.EventHandler(Page_Init);
		}
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			if (Page.IsPostBack == false) 
			{

				bookshop.BookDBO cart = new bookshop.BookDBO();				
				String cartId = cart.GetShoppingCartId();

				MyDataGrid.DataSource = cart.DisplayShoppingCart(cartId);
				MyDataGrid.DataBind();

				TotalLbl.Text = String.Format( "{0:c}", cart.ShoppingCartTotalCost(cartId));
			}
		}

		#region Web ������������ɵĴ���
		
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{    
			this.SubmitBtn.Click += new System.EventHandler(this.SubmitBtn_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void SubmitBtn_Click(object sender, System.EventArgs e)
		{
			bookshop.BookDBO cart = new bookshop.BookDBO();

			// Calculate end-user's shopping cart ID
			String cartId = cart.GetShoppingCartId();

			// Calculate end-user's customerID
			String customerId="1";
			//String customerId = User.Identity.Name;

			if ((cartId != null) && (customerId != null)) 
			{

				// Place the order
				bookshop.BookDBO ordersDatabase = new bookshop.BookDBO();
				
				int orderId = ordersDatabase.PlaceOrder(customerId, cartId);

				//Update labels to reflect the fact that the order has taken place
				Header.Text="�������";
				Message.Text = "<b>�������Ϊ�� </b>" + orderId;
				SubmitBtn.Visible = false;
			}
		}
		private void Page_Init(object sender, EventArgs e) 
		{
			
			InitializeComponent();
		}
	}
}
