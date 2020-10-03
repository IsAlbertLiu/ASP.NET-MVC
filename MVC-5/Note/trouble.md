# 1. Html.ActionLink 添加样式

正确

 @Html.ActionLink("修改", "ModifyAdminUser", new { Id = item.Id },new { @class = "a_purse" })

 @Html.ActionLink("新增", "ModifyAdminUser",new { }, new { @class = "a_purse" })

错误

 @Html.ActionLink("修改", "ModifyAdminUser", new { Id = item.Id , @class = "a_purse" })

 @Html.ActionLink("新增", "ModifyAdminUser",new { @class = "a_purse" })