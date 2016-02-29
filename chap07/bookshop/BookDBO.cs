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
	/// BookDBO 的摘要说明。
	/// </summary>
	public class BookDBO
	{
		public BookDBO()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		public SqlDataReader GetUserOrders(String UserID) 
		{

			//创建数据库连接和命令的对象
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlCommand myCommand = new SqlCommand("ListOrders", myConnection);

			//指明Sql命令的操作类型是使用存储过程
			myCommand.CommandType = CommandType.StoredProcedure;

			//给存储过程添加参数
			SqlParameter parameterUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
			parameterUserID.Value = Int32.Parse(UserID);
			myCommand.Parameters.Add(parameterUserID);

			//打开数据库连接
			myConnection.Open();
			//执行数据操作命令
			//SqlDataReader读取数据到记录集后，会自动关闭数据库的连接
			SqlDataReader result = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

			//返回DataReader的结果
			return result;
		}

		//GetOrderDetails方法用于查询订单的详细信息
		public OrderDetails GetOrderDetails(int orderID, string userID) 
		{

			//创建数据库连接和命令的对象
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlDataAdapter myCommand = new SqlDataAdapter("OrdersDetail", myConnection);

			//指明Sql命令的操作类型是使用存储过程
			myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

			//给存储过程添加参数
			SqlParameter parameterOrderID = new SqlParameter("@OrderID", SqlDbType.Int, 4);
			parameterOrderID.Value = orderID;
			myCommand.SelectCommand.Parameters.Add(parameterOrderID);

			SqlParameter parameterUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
			parameterUserID.Value = Int32.Parse(userID);
			myCommand.SelectCommand.Parameters.Add(parameterUserID);

			SqlParameter parameterOrderDate = new SqlParameter("@OrderDate", SqlDbType.DateTime, 8);
			//指出该参数是存储过程的OUTPUT参数
			parameterOrderDate.Direction = ParameterDirection.Output;
			myCommand.SelectCommand.Parameters.Add(parameterOrderDate);

			SqlParameter parameterOrderTotalCost = new SqlParameter("@OrderTotalCost", SqlDbType.Money, 8);
			parameterOrderTotalCost.Direction = ParameterDirection.Output;
			myCommand.SelectCommand.Parameters.Add(parameterOrderTotalCost);

			//创建数据集
			DataSet myDataSet = new DataSet();
			//往数据集里面填充数据
			myCommand.Fill(myDataSet, "OrderItems");
            
			//创建OrderDetails类的对象
			OrderDetails myOrderDetails = new OrderDetails();
			//利用存储过程的参数给对象myOrderDetails赋值
			myOrderDetails.OrderDate = (DateTime)parameterOrderDate.Value;
			myOrderDetails.OrderTotalCost = (decimal)parameterOrderTotalCost.Value;
			myOrderDetails.OrderItems = myDataSet;

			//返回数据
			return myOrderDetails;
		}

		// PlaceOrder方法往数据库里面添加新的订单记录，同时清空当前对应的购物车里面的所有商品
		
		public int PlaceOrder(string UserID, string cartID) 
		{

			//创建数据库连接和命令的对象
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlCommand myCommand = new SqlCommand("AddOrder", myConnection);

			//指明Sql命令的操作类型是使用存储过程
			myCommand.CommandType = CommandType.StoredProcedure;

			//给存储过程添加参数
			SqlParameter parameterUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
			parameterUserID.Value = Int32.Parse(UserID);
			myCommand.Parameters.Add(parameterUserID);
			//给存储过程添加参数
			SqlParameter parameterCartID = new SqlParameter("@ShoppingCartID", SqlDbType.NVarChar, 50);
			parameterCartID.Value = cartID;
			myCommand.Parameters.Add(parameterCartID);
			//给存储过程添加参数
			SqlParameter parameterOrderDate = new SqlParameter("@OrderDate", SqlDbType.DateTime, 8);
			parameterOrderDate.Value = DateTime.Now;
			myCommand.Parameters.Add(parameterOrderDate);
			
			SqlParameter parameterOrderID = new SqlParameter("@OrderID", SqlDbType.Int, 4);
			//指出该参数是存储过程的OUTPUT参数
			parameterOrderID.Direction = ParameterDirection.Output;
			myCommand.Parameters.Add(parameterOrderID);

			//打开数据库连接
			myConnection.Open();
			//进行数据库操作
			myCommand.ExecuteNonQuery();
			//关闭数据库连接
			myConnection.Close();

			//利用存储过程的OUTPUT参数返回OrderID
			return (int)parameterOrderID.Value;
		}
		
		// DisplayShoppingCart方法显示一个购物车的所包含的所有商品的列表
		
		public SqlDataReader DisplayShoppingCart(string cartID) 
		{
			//创建数据库连接和命令的对象
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlCommand myCommand = new SqlCommand("DisplayShoppingCart", myConnection);

			//指明Sql命令的操作类型是使用存储过程
			myCommand.CommandType = CommandType.StoredProcedure;

			//给存储过程添加参数
			SqlParameter parameterCartID = new SqlParameter("@CartID", SqlDbType.NVarChar, 50);
			parameterCartID.Value = cartID;
			myCommand.Parameters.Add(parameterCartID);

			//打开数据库连接
			myConnection.Open();
			//执行数据操作命令
			//SqlDataReader读取数据到记录集后，会自动关闭数据库的连接
			SqlDataReader result = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

			//返回DataReader的结果
			return result;
		}
		
		// AddItemtoShoppingCart方法负责往购物车里面添加一个新的商品
		
		public void AddItemtoShoppingCart(string cartID, int bookID, int quantity) 
		{

			//创建数据库连接和命令的对象
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlCommand myCommand = new SqlCommand("AddItemtoShoppingCart", myConnection);

			//指明Sql命令的操作类型是使用存储过程
			myCommand.CommandType = CommandType.StoredProcedure;

			//给存储过程添加参数
			SqlParameter parameterwareID = new SqlParameter("@bookID", SqlDbType.Int, 4);
			parameterwareID.Value = bookID;
			myCommand.Parameters.Add(parameterwareID);

			SqlParameter parameterCartID = new SqlParameter("@ShoppingCartID", SqlDbType.NVarChar, 50);
			parameterCartID.Value = cartID;
			myCommand.Parameters.Add(parameterCartID);

			SqlParameter parameterQuantity = new SqlParameter("@bookQuantity", SqlDbType.Int, 4);
			parameterQuantity.Value = quantity;
			myCommand.Parameters.Add(parameterQuantity);

			//打开数据库连接
			myConnection.Open();
			//进行数据库操作
			myCommand.ExecuteNonQuery();
			//关闭数据库连接
			myConnection.Close();
		}


		
		// ShoppingCartUpdate方法用于更新购物车里某件商品的购买数量
		
		public void ShoppingCartUpdate(string cartID, int bookID, int quantity) 
		{			
			if (quantity < 0) 
			{
				throw new Exception("购买商品的数量不能为负数");
			}

			//创建数据库连接和命令的对象
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlCommand myCommand = new SqlCommand("UpdateShoppingCart", myConnection);

			//指明Sql命令的操作类型是使用存储过程
			myCommand.CommandType = CommandType.StoredProcedure;

			//给存储过程添加参数
			SqlParameter parameterShoppingCartID = new SqlParameter("@ShoppingCartID", SqlDbType.NVarChar, 50);
			parameterShoppingCartID.Value = cartID;
			myCommand.Parameters.Add(parameterShoppingCartID);

			SqlParameter parameterwareID = new SqlParameter("@bookID", SqlDbType.Int, 4);
			parameterwareID.Value = bookID;
			myCommand.Parameters.Add(parameterwareID);

			SqlParameter parameterwareQuantity = new SqlParameter("@bookQuantity", SqlDbType.Int, 4);
			parameterwareQuantity.Value = quantity;
			myCommand.Parameters.Add(parameterwareQuantity);

			//打开数据库连接
			myConnection.Open();
			//进行数据库操作
			myCommand.ExecuteNonQuery();
			//关闭数据库连接
			myConnection.Close();
		}


		
		// ShoppingCartRemoveItem方法用于从购物车中删除一种商品。
		
		public void ShoppingCartRemoveItem(string cartID, int bookID) 
		{
			//创建数据库连接和命令的对象
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlCommand myCommand = new SqlCommand("RemoveShoppingCartItem", myConnection);

			//指明Sql命令的操作类型是使用存储过程
			myCommand.CommandType = CommandType.StoredProcedure;

			//给存储过程添加参数
			SqlParameter parameterShoppingCartID = new SqlParameter("@ShoppingCartID", SqlDbType.Int, 4);
			parameterShoppingCartID.Value = cartID;
			myCommand.Parameters.Add(parameterShoppingCartID);

			SqlParameter parameterwareID = new SqlParameter("@bookID", SqlDbType.NVarChar, 50);
			parameterwareID.Value = bookID;
			myCommand.Parameters.Add(parameterwareID);

			//打开数据库连接
			myConnection.Open();
			//进行数据库操作
			myCommand.ExecuteNonQuery();
			//关闭数据库连接
			myConnection.Close();
		}

		// CountShoppingCartItem方法返回购物车中商品种类的数量
		
		public int CountShoppingCartItem(string cartID) 
		{

			//创建数据库连接和命令的对象
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlCommand myCommand = new SqlCommand("CountShoppingCartItem", myConnection);

			//指明Sql命令的操作类型是使用存储过程
			myCommand.CommandType = CommandType.StoredProcedure;

			//给存储过程添加参数
			SqlParameter parameterCartID = new SqlParameter("@ShoppingCartID", SqlDbType.NVarChar, 50);
			parameterCartID.Value = cartID;
			myCommand.Parameters.Add(parameterCartID);

			SqlParameter parameterItemCount = new SqlParameter("@ItemCount", SqlDbType.Int, 4);
			parameterItemCount.Direction = ParameterDirection.Output;
			myCommand.Parameters.Add(parameterItemCount);

			//打开数据库连接
			myConnection.Open();
			//进行数据库操作
			myCommand.ExecuteNonQuery();
			//关闭数据库连接
			myConnection.Close();

			//利用存储过程的OUTPUT参数返回ItemCount，即商品的数量
			return ((int)parameterItemCount.Value);
		}


		
		// ShoppingCartTotalCost方法返回购物车中所有商品的价格总额
		
		public decimal ShoppingCartTotalCost(string cartID) 
		{

			//创建数据库连接和命令的对象
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlCommand myCommand = new SqlCommand("ShoppingCartTotalCost", myConnection);

			//指明Sql命令的操作类型是使用存储过程
			myCommand.CommandType = CommandType.StoredProcedure;

			//给存储过程添加参数
			SqlParameter parameterCartID = new SqlParameter("@ShoppingCartID", SqlDbType.NVarChar, 50);
			parameterCartID.Value = cartID;
			myCommand.Parameters.Add(parameterCartID);

			SqlParameter parameterTotalCost = new SqlParameter("@TotalCost", SqlDbType.Money, 8);
			parameterTotalCost.Direction = ParameterDirection.Output;
			myCommand.Parameters.Add(parameterTotalCost);

			myConnection.Open();
			myCommand.ExecuteNonQuery();
			myConnection.Close();

			//返回价格总额
			if (parameterTotalCost.Value.ToString() != "") 
			{
				return (decimal)parameterTotalCost.Value;
			}
			else 
			{
				return 0;
			}
		}


		
		// TransplantShoppingCart方法用于把一个购物车里面的商品转移到另一个购物车里面去。
	
		
		public void TransplantShoppingCart(String oldCartId, String newCartId) 
		{

			//创建数据库连接和命令的对象
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlCommand myCommand = new SqlCommand("TransplantShoppingCart", myConnection);

			//指明Sql命令的操作类型是使用存储过程
			myCommand.CommandType = CommandType.StoredProcedure;

			//给存储过程添加参数
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

		
		
		// ShoppingCartEmpty方法用于清空一个购物车里面的所有商品
	
		public void ShoppingCartEmpty(string cartID) 
		{

			//创建数据库连接和命令的对象
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlCommand myCommand = new SqlCommand("EmptyShoppingCart", myConnection);

			//指明Sql命令的操作类型是使用存储过程
			myCommand.CommandType = CommandType.StoredProcedure;

			//给存储过程添加参数
			SqlParameter cartid = new SqlParameter("@ShoppingCartID", SqlDbType.NVarChar, 50);
			cartid.Value = cartID;
			myCommand.Parameters.Add(cartid);

			myConnection.Open();
			myCommand.ExecuteNonQuery();
			myConnection.Close();
		}


		
		// GetShoppingCartId方法用于生成一个购物车ID来跟踪本商城的顾客的购物行为
		
		public String GetShoppingCartId() 
		{
			
			System.Web.HttpContext thecontext = System.Web.HttpContext.Current;

			//如果用户已经通过登录认证或者注册完毕，则使用该用户的UserID作为永久购物车的ID，并返回这个ID
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
				//产生一个新的随机的GUID
				Guid tempShoppingCartId = Guid.NewGuid();

				//把tempCartId发送到客户端，并作为一个cookie保存下来
				thecontext.Response.Cookies["IStore_CartID"].Value = tempShoppingCartId.ToString();

				//函数返回这个tempCartId
				return tempShoppingCartId.ToString();
			}
		}

	}

}

