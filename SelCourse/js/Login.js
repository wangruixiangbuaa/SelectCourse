$(document).ready(function () {
    $("#login").click(function () {
        var name = $('input[name=username]').val();
        var password = $('input[name=password]').val();
        $.ajax({
            type: "Get", //提交方式 
            dataType: "json",
            url: "/Login/DoLogin?username=" + encodeURI(name) + "&password=" + encodeURI(password),//路径 
            success: function (result) {//返回数据根据结果进行相应的处理 
                console.log(result);
                if (result.Status == "loginFail") {
                    alert("登录失败,请检查用户名和密码。");
                    window.location.replace(sc.loginUrl);
                }
                if (result.StuInfo.IsAdmin == "1") {
                    window.location.replace(sc.courseUrl);
                }
                if (result.StuInfo.IsAdmin == "0") {
                    window.location.replace(sc.selectCourseUrl);
                }
            }, error: function (XMLHttpRequest, textStatus, errorThrown) {
                console.log(textStatus);
            }
        });
    });

    $("#loginPost").click(function () {
        var stu = {};
        stu.StuName = $('input[name=username]').val();
        stu.StuIphone = $('input[name=password]').val();
        $.ajax({
            type: "Post", //提交方式 
            dataType: "json",
            url: "/Login/DoPostLogin",//路径 
            data:JSON.stringify(stu),
            success: function (result) {//返回数据根据结果进行相应的处理 
                console.log(result);
                if (result.Status == "loginFail") {
                    alert("登录失败,请检查用户名和密码。");
                    window.location.replace("http://localhost:13433/Login");
                }
                if (result.StuInfo.IsAdmin == "1") {
                    window.location.replace("http://localhost:13433/Course");
                }
                if (result.StuInfo.IsAdmin == "0") {
                    window.location.replace("http://localhost:13433/Course/SelectCourse");
                }
            }, error: function (XMLHttpRequest, textStatus, errorThrown) {
                console.log(textStatus);
            }
        });
    });
});