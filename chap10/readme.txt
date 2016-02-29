                                                安装及使用须知
1、数据库安装：

 
   运行Microsoft SQL Server 2000的SQL 查询分析器，打开文件夹TeleComm下的TeleComm.sql文件，然后选择菜单“查询”|“执行”命令即可生成所需的数据库和数据库表；分别打开文件夹TeleCommServices下的ChargeManageServices.sql、CustomerInquiryServices.sql和OperatorManageServices.sql文件，选择菜单“查询”|“执行”命令即可生成服务所需的存储过程。

2、Web服务的安装
  把源代码的TeleCommServices文件夹拷贝到系统的Inetpub\wwwroot目录中，取消文件夹的只读属性，然后在IIS上设置虚拟目录即可。具体步骤是：打开IIS服务器，在TeleCommServices站点上右击，在弹出菜单上选择“属性”命令，弹出“TeleCommServices属性”对话框。在“TeleCommServices属性”对话框的“目录”选项卡上单击“创建”按钮。

3、把源代码的TeleComm文件夹拷贝到硬盘上，取消文件夹及其子目录和文件的只读属性。如果您安装的是Microsoft Visual Studio .Net 2003，那么可以直接打开ChargeManageForm文件夹、CustomerInquiryForm文件夹和OperatorManageForm文件夹下的工程，查看代码并进行调试。
