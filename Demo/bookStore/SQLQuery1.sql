create table Books  
(  
BookId int primary key not null, --书籍ID,primary key 该字段为标示，增量为1--  
AuthorName nvarchar(50) not null, --作者姓名，不能为空--  
Title nvarchar(160) not null, --，书名，不能为空not null--  
Price numeric(10,2)   not null,--书籍价格，不能为空--
BookCoverUrl nvarchar(1024)--书籍封面url ，可以为空--
)  