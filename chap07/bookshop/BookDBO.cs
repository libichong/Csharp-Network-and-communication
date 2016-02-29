using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace bookshop
{
	public class wareDetails 
	{
		public String  ModelNumber;
		public String  ModelName;	
		public decimal UnitCost;
		public String  Description;
	}


	public class OrderDetails 
	{

		public DateTime  OrderDate;
		public decimal   OrderTotalCost;
		public DataSet   OrderItems;
	}
	/// <summary>
	/// BookDBO ��ժҪ˵����
	/// </summary>
	public class BookDBO
	{
		public BookDBO()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		public SqlDataReader GetUserOrders(String UserID) 
		{

			//�������ݿ����Ӻ�����Ķ���
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlCommand myCommand = new SqlCommand("ListOrders", myConnection);

			//ָ��Sql����Ĳ���������ʹ�ô洢����
			myCommand.CommandType = CommandType.StoredProcedure;

			//���洢������Ӳ���
			SqlParameter parameterUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
			parameterUserID.Value = Int32.Parse(UserID);
			myCommand.Parameters.Add(parameterUserID);

			//�����ݿ�����
			myConnection.Open();
			//ִ�����ݲ�������
			//SqlDataReader��ȡ���ݵ���¼���󣬻��Զ��ر����ݿ������
			SqlDataReader result = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

			//����DataReader�Ľ��
			return result;
		}

		//GetOrderDetails�������ڲ�ѯ��������ϸ��Ϣ
		public OrderDetails GetOrderDetails(int orderID, string userID) 
		{

			//�������ݿ����Ӻ�����Ķ���
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlDataAdapter myCommand = new SqlDataAdapter("OrdersDetail", myConnection);

			//ָ��Sql����Ĳ���������ʹ�ô洢����
			myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

			//���洢������Ӳ���
			SqlParameter parameterOrderID = new SqlParameter("@OrderID", SqlDbType.Int, 4);
			parameterOrderID.Value = orderID;
			myCommand.SelectCommand.Parameters.Add(parameterOrderID);

			SqlParameter parameterUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
			parameterUserID.Value = Int32.Parse(userID);
			myCommand.SelectCommand.Parameters.Add(parameterUserID);

			SqlParameter parameterOrderDate = new SqlParameter("@OrderDate", SqlDbType.DateTime, 8);
			//ָ���ò����Ǵ洢���̵�OUTPUT����
			parameterOrderDate.Direction = ParameterDirection.Output;
			myCommand.SelectCommand.Parameters.Add(parameterOrderDate);

			SqlParameter parameterOrderTotalCost = new SqlParameter("@OrderTotalCost", SqlDbType.Money, 8);
			parameterOrderTotalCost.Direction = ParameterDirection.Output;
			myCommand.SelectCommand.Parameters.Add(parameterOrderTotalCost);

			//�������ݼ�
			DataSet myDataSet = new DataSet();
			//�����ݼ������������
			myCommand.Fill(myDataSet, "OrderItems");
            
			//����OrderDetails��Ķ���
			OrderDetails myOrderDetails = new OrderDetails();
			//���ô洢���̵Ĳ���������myOrderDetails��ֵ
			myOrderDetails.OrderDate = (DateTime)parameterOrderDate.Value;
			myOrderDetails.OrderTotalCost = (decimal)parameterOrderTotalCost.Value;
			myOrderDetails.OrderItems = myDataSet;

			//��������
			return myOrderDetails;
		}

		// PlaceOrder���������ݿ���������µĶ�����¼��ͬʱ��յ�ǰ��Ӧ�Ĺ��ﳵ�����������Ʒ
		
		public int PlaceOrder(string UserID, string cartID) 
		{

			//�������ݿ����Ӻ�����Ķ���
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlCommand myCommand = new SqlCommand("AddOrder", myConnection);

			//ָ��Sql����Ĳ���������ʹ�ô洢����
			myCommand.CommandType = CommandType.StoredProcedure;

			//���洢������Ӳ���
			SqlParameter parameterUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
			parameterUserID.Value = Int32.Parse(UserID);
			myCommand.Parameters.Add(parameterUserID);
			//���洢������Ӳ���
			SqlParameter parameterCartID = new SqlParameter("@ShoppingCartID", SqlDbType.NVarChar, 50);
			parameterCartID.Value = cartID;
			myCommand.Parameters.Add(parameterCartID);
			//���洢������Ӳ���
			SqlParameter parameterOrderDate = new SqlParameter("@OrderDate", SqlDbType.DateTime, 8);
			parameterOrderDate.Value = DateTime.Now;
			myCommand.Parameters.Add(parameterOrderDate);
			
			SqlParameter parameterOrderID = new SqlParameter("@OrderID", SqlDbType.Int, 4);
			//ָ���ò����Ǵ洢���̵�OUTPUT����
			parameterOrderID.Direction = ParameterDirection.Output;
			myCommand.Parameters.Add(parameterOrderID);

			//�����ݿ�����
			myConnection.Open();
			//�������ݿ����
			myCommand.ExecuteNonQuery();
			//�ر����ݿ�����
			myConnection.Close();

			//���ô洢���̵�OUTPUT��������OrderID
			return (int)parameterOrderID.Value;
		}
		
		// DisplayShoppingCart������ʾһ�����ﳵ����������������Ʒ���б�
		
		public SqlDataReader DisplayShoppingCart(string cartID) 
		{
			//�������ݿ����Ӻ�����Ķ���
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlCommand myCommand = new SqlCommand("DisplayShoppingCart", myConnection);

			//ָ��Sql����Ĳ���������ʹ�ô洢����
			myCommand.CommandType = CommandType.StoredProcedure;

			//���洢������Ӳ���
			SqlParameter parameterCartID = new SqlParameter("@CartID", SqlDbType.NVarChar, 50);
			parameterCartID.Value = cartID;
			myCommand.Parameters.Add(parameterCartID);

			//�����ݿ�����
			myConnection.Open();
			//ִ�����ݲ�������
			//SqlDataReader��ȡ���ݵ���¼���󣬻��Զ��ر����ݿ������
			SqlDataReader result = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

			//����DataReader�Ľ��
			return result;
		}
		
		// AddItemtoShoppingCart�������������ﳵ�������һ���µ���Ʒ
		
		public void AddItemtoShoppingCart(string cartID, int bookID, int quantity) 
		{

			//�������ݿ����Ӻ�����Ķ���
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlCommand myCommand = new SqlCommand("AddItemtoShoppingCart", myConnection);

			//ָ��Sql����Ĳ���������ʹ�ô洢����
			myCommand.CommandType = CommandType.StoredProcedure;

			//���洢������Ӳ���
			SqlParameter parameterwareID = new SqlParameter("@bookID", SqlDbType.Int, 4);
			parameterwareID.Value = bookID;
			myCommand.Parameters.Add(parameterwareID);

			SqlParameter parameterCartID = new SqlParameter("@ShoppingCartID", SqlDbType.NVarChar, 50);
			parameterCartID.Value = cartID;
			myCommand.Parameters.Add(parameterCartID);

			SqlParameter parameterQuantity = new SqlParameter("@bookQuantity", SqlDbType.Int, 4);
			parameterQuantity.Value = quantity;
			myCommand.Parameters.Add(parameterQuantity);

			//�����ݿ�����
			myConnection.Open();
			//�������ݿ����
			myCommand.ExecuteNonQuery();
			//�ر����ݿ�����
			myConnection.Close();
		}


		
		// ShoppingCartUpdate�������ڸ��¹��ﳵ��ĳ����Ʒ�Ĺ�������
		
		public void ShoppingCartUpdate(string cartID, int bookID, int quantity) 
		{			
			if (quantity < 0) 
			{
				throw new Exception("������Ʒ����������Ϊ����");
			}

			//�������ݿ����Ӻ�����Ķ���
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlCommand myCommand = new SqlCommand("UpdateShoppingCart", myConnection);

			//ָ��Sql����Ĳ���������ʹ�ô洢����
			myCommand.CommandType = CommandType.StoredProcedure;

			//���洢������Ӳ���
			SqlParameter parameterShoppingCartID = new SqlParameter("@ShoppingCartID", SqlDbType.NVarChar, 50);
			parameterShoppingCartID.Value = cartID;
			myCommand.Parameters.Add(parameterShoppingCartID);

			SqlParameter parameterwareID = new SqlParameter("@bookID", SqlDbType.Int, 4);
			parameterwareID.Value = bookID;
			myCommand.Parameters.Add(parameterwareID);

			SqlParameter parameterwareQuantity = new SqlParameter("@bookQuantity", SqlDbType.Int, 4);
			parameterwareQuantity.Value = quantity;
			myCommand.Parameters.Add(parameterwareQuantity);

			//�����ݿ�����
			myConnection.Open();
			//�������ݿ����
			myCommand.ExecuteNonQuery();
			//�ر����ݿ�����
			myConnection.Close();
		}


		
		// ShoppingCartRemoveItem�������ڴӹ��ﳵ��ɾ��һ����Ʒ��
		
		public void ShoppingCartRemoveItem(string cartID, int bookID) 
		{
			//�������ݿ����Ӻ�����Ķ���
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlCommand myCommand = new SqlCommand("RemoveShoppingCartItem", myConnection);

			//ָ��Sql����Ĳ���������ʹ�ô洢����
			myCommand.CommandType = CommandType.StoredProcedure;

			//���洢������Ӳ���
			SqlParameter parameterShoppingCartID = new SqlParameter("@ShoppingCartID", SqlDbType.Int, 4);
			parameterShoppingCartID.Value = cartID;
			myCommand.Parameters.Add(parameterShoppingCartID);

			SqlParameter parameterwareID = new SqlParameter("@bookID", SqlDbType.NVarChar, 50);
			parameterwareID.Value = bookID;
			myCommand.Parameters.Add(parameterwareID);

			//�����ݿ�����
			myConnection.Open();
			//�������ݿ����
			myCommand.ExecuteNonQuery();
			//�ر����ݿ�����
			myConnection.Close();
		}

		// CountShoppingCartItem�������ع��ﳵ����Ʒ���������
		
		public int CountShoppingCartItem(string cartID) 
		{

			//�������ݿ����Ӻ�����Ķ���
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlCommand myCommand = new SqlCommand("CountShoppingCartItem", myConnection);

			//ָ��Sql����Ĳ���������ʹ�ô洢����
			myCommand.CommandType = CommandType.StoredProcedure;

			//���洢������Ӳ���
			SqlParameter parameterCartID = new SqlParameter("@ShoppingCartID", SqlDbType.NVarChar, 50);
			parameterCartID.Value = cartID;
			myCommand.Parameters.Add(parameterCartID);

			SqlParameter parameterItemCount = new SqlParameter("@ItemCount", SqlDbType.Int, 4);
			parameterItemCount.Direction = ParameterDirection.Output;
			myCommand.Parameters.Add(parameterItemCount);

			//�����ݿ�����
			myConnection.Open();
			//�������ݿ����
			myCommand.ExecuteNonQuery();
			//�ر����ݿ�����
			myConnection.Close();

			//���ô洢���̵�OUTPUT��������ItemCount������Ʒ������
			return ((int)parameterItemCount.Value);
		}


		
		// ShoppingCartTotalCost�������ع��ﳵ��������Ʒ�ļ۸��ܶ�
		
		public decimal ShoppingCartTotalCost(string cartID) 
		{

			//�������ݿ����Ӻ�����Ķ���
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlCommand myCommand = new SqlCommand("ShoppingCartTotalCost", myConnection);

			//ָ��Sql����Ĳ���������ʹ�ô洢����
			myCommand.CommandType = CommandType.StoredProcedure;

			//���洢������Ӳ���
			SqlParameter parameterCartID = new SqlParameter("@ShoppingCartID", SqlDbType.NVarChar, 50);
			parameterCartID.Value = cartID;
			myCommand.Parameters.Add(parameterCartID);

			SqlParameter parameterTotalCost = new SqlParameter("@TotalCost", SqlDbType.Money, 8);
			parameterTotalCost.Direction = ParameterDirection.Output;
			myCommand.Parameters.Add(parameterTotalCost);

			myConnection.Open();
			myCommand.ExecuteNonQuery();
			myConnection.Close();

			//���ؼ۸��ܶ�
			if (parameterTotalCost.Value.ToString() != "") 
			{
				return (decimal)parameterTotalCost.Value;
			}
			else 
			{
				return 0;
			}
		}


		
		// TransplantShoppingCart�������ڰ�һ�����ﳵ�������Ʒת�Ƶ���һ�����ﳵ����ȥ��
	
		
		public void TransplantShoppingCart(String oldCartId, String newCartId) 
		{

			//�������ݿ����Ӻ�����Ķ���
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlCommand myCommand = new SqlCommand("TransplantShoppingCart", myConnection);

			//ָ��Sql����Ĳ���������ʹ�ô洢����
			myCommand.CommandType = CommandType.StoredProcedure;

			//���洢������Ӳ���
			SqlParameter cart1 = new SqlParameter("@OldShoppingCartId ", SqlDbType.NVarChar, 50);
			cart1.Value = oldCartId;
			myCommand.Parameters.Add(cart1);

			SqlParameter cart2 = new SqlParameter("@NewShoppingCartId ", SqlDbType.NVarChar, 50);
			cart2.Value = newCartId;
			myCommand.Parameters.Add(cart2);

			myConnection.Open();
			myCommand.ExecuteNonQuery();
			myConnection.Close();
		}

		
		
		// ShoppingCartEmpty�����������һ�����ﳵ�����������Ʒ
	
		public void ShoppingCartEmpty(string cartID) 
		{

			//�������ݿ����Ӻ�����Ķ���
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlCommand myCommand = new SqlCommand("EmptyShoppingCart", myConnection);

			//ָ��Sql����Ĳ���������ʹ�ô洢����
			myCommand.CommandType = CommandType.StoredProcedure;

			//���洢������Ӳ���
			SqlParameter cartid = new SqlParameter("@ShoppingCartID", SqlDbType.NVarChar, 50);
			cartid.Value = cartID;
			myCommand.Parameters.Add(cartid);

			myConnection.Open();
			myCommand.ExecuteNonQuery();
			myConnection.Close();
		}


		
		// GetShoppingCartId������������һ�����ﳵID�����ٱ��̳ǵĹ˿͵Ĺ�����Ϊ
		
		public String GetShoppingCartId() 
		{
			
			System.Web.HttpContext thecontext = System.Web.HttpContext.Current;

			//����û��Ѿ�ͨ����¼��֤����ע����ϣ���ʹ�ø��û���UserID��Ϊ���ù��ﳵ��ID�����������ID
			if (thecontext.User.Identity.Name != "") 
			{
				return thecontext.User.Identity.Name;
			}			
			if (thecontext.Request.Cookies["IStore_CartID"] != null) 
			{
				return thecontext.Request.Cookies["IStore_CartID"].Value;
			}
			else 
			{
				//����һ���µ������GUID
				Guid tempShoppingCartId = Guid.NewGuid();

				//��tempCartId���͵��ͻ��ˣ�����Ϊһ��cookie��������
				thecontext.Response.Cookies["IStore_CartID"].Value = tempShoppingCartId.ToString();

				//�����������tempCartId
				return tempShoppingCartId.ToString();
			}
		}

	}

}

