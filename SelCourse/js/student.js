$(document).ready(function () {

    $('#search').click(function () {
        $.ajax({
            type: "Get", //提交方式 
            url: "/Student/Search?stuName=" + $('#stuname').val() + "&course=" + $('#course').val(),//路径 
            success: function (result) {//返回数据根据结果进行相应的处理 
                console.log(result);
                window.location.replace(sc.studentUrl + "?courseid=" + $('#course').attr('cid') + "&stuName=" + $('#stuname').val());
            }
        });
    });
    $('#back').click(function () {
        window.location.replace(sc.courseUrl);
    })
});