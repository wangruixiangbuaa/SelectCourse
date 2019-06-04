$(document).ready(function () {

    $('#selectCourseName').change(function () {
        var type = $(this).val();
        window.location.replace(sc.selectCourseUrl + "?courseName=" + type);
    })

    $('#save').click(function () {
        var checks = $('input[type=checkbox]')
        console.log($('input[type=chekbox]'))
        var id = '';
        //获取当前选中的checkbox,拼接传入后台的id,放入url里面
        for (var i = 0; i < checks.length; i++) {
            if (checks[i].checked)
            {
                id += checks[i].getAttribute("cid") + ","
            }
        }
        //当前选课的url
        var url = "/Course/SelectCourseSave?cids=" + id;
        console.log(name);
        $.ajax({
            type: "Get", //提交方式
            url: url,//路径
            success: function (result) { //返回数据根据结果进行相应的处理
                console.log(result);
                if (result != '' && result != null)
                {
                    alert(result);
                }
                window.location.replace(sc.selectCourseUrl);
            }
        });

    });
});