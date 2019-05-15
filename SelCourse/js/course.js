$(document).ready(function () {
    $('#save').click(function () {
        var id = $('#course-id').val();
        var name = $('#course-name').val();
        var des = $('#course-remark').val();
        var type = $('#course-type').val();
        var num = $('#course-num').val();
        var url = "/Course/AddCourse?name=" + encodeURI(name) + "&des=" + encodeURI(des) + "&type=" + encodeURI(type) + "&num=" + num;
        console.log(id + '--' + name + '--' + des);
        if (id == '' || id == null) {
            url = "/Course/AddCourse?name=" + encodeURI(name) + "&des=" + encodeURI(des) + "&type=" + encodeURI(type) + "&num=" + num;

        } else {
            url = "/Course/UpdateCourse?name=" + encodeURI(name) + "&des=" + encodeURI(des) + "&type=" + encodeURI(type) + "&num=" + num + "&id=" + id;
        }
        console.log(name);
        $.ajax({
            type: "Get", //提交方式 
            url: url,//路径 
            success: function (result) {
                //返回数据根据结果进行相应的处理 
                console.log(result);
                window.location.replace("http://localhost:13433/Course");
            }
        });

    });
    $('.showstudent').click(function () {
        window.location.replace("http://localhost:13433/Student?courseid=" + $(this).attr("cid"));
    })
    $('#add').click(function () {
        $('#course-id').val('');
        $('#myModal').modal('show');
    })
    $('.update').click(function () {

        $('#course-name').val($(this).attr("cname"));
        $('#course-type').val($(this).attr("ctype"));
        $('#course-remark').val($(this).attr("cdes"));
        $('#course-num').val($(this).attr("ctotal"));
        $('#course-id').val($(this).attr("cid"));
        $('#myModal').modal('show');

    })
    $('#courseTypeSelect').change(function () {
        var type = $(this).val();
        window.location.replace("http://localhost:13433/Course?type="+type);
    })
    $('#goout').click(function () {
        window.location.replace("http://localhost:13433/Login");
    })
    $('.delete').click(function () {
        var id = $(this).attr("cid");
        $.ajax({
            type: "Get", //提交方式 
            url: "/Course/DeleteCourse?id=" + id,//路径 
            success: function (result) {//返回数据根据结果进行相应的处理 
                console.log(result);
                window.location.replace("http://localhost:13433/Course");
            }
        });
    })
});