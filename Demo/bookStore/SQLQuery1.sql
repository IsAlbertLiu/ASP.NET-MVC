create table Books  
(  
BookId int primary key not null, --�鼮ID,primary key ���ֶ�Ϊ��ʾ������Ϊ1--  
AuthorName nvarchar(50) not null, --��������������Ϊ��--  
Title nvarchar(160) not null, --������������Ϊ��not null--  
Price numeric(10,2)   not null,--�鼮�۸񣬲���Ϊ��--
BookCoverUrl nvarchar(1024)--�鼮����url ������Ϊ��--
)  