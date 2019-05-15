$(document).ready(function () {
    $('#save').click(function () {
        var checks = $('input[type=checkbox]')
        console.log(checks);

        var id = '';
        for (var i = 0; i < checks.length; i++) {
            if (checks[i].checked)
            {
                id += checks[i].getAttribute("cid") + ","
            }
        }
        var url = "/Course/SelectCourseSave?cids=" + id;
        console.log(name);
        $.ajax({
            type: "Get", //提交方式
            url: url,//路径
            success: function (result) {//返回数据根据结果进行相应的处理
                console.log(result);
                window.location.replace("http://localhost:13433/Course/SelectCourse");
            }
        });

    });
});