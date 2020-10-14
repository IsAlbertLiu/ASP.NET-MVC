$(function () {

    $('#saveNews').linkbutton().click(function () {

        $('#form1').form('submit', {
            url: "/Architecture_New/NewSave/",
            onSubmit: function () {
                return $(this).form('validate');
            },
            success: function (result) {

                if (result) {

                    $.messager.alert("提示", "恭喜您，保存成功", "info");
                    $('#form1').form('clear');
                }
                else {
                    $.messager.alert("提示", "添加失败，请重新操作(请检查图片是否为空)！", "info");
                    //return;

                }


            }
        });


    });



});

console.log(1);