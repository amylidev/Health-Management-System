function ShowTime() {
    var NowDate = new Date();
    var y = NowDate.getFullYear();
    var mo = NowDate.getMonth() + 1;
    var d = NowDate.getDate();
    var h = NowDate.getHours();
    var mi = NowDate.getMinutes();
    var s = NowDate.getSeconds();
    document.getElementById('showbox').innerHTML = '現在時間為' + y + '年' + mo + '月' + d + '日' + h + '時' + mi + '分' + s + '秒';
    setTimeout('ShowTime()', 1000);
}
$(document).ready(function () {
    //  讓 #menu 的寬度自動根據 main 的數量而變
    $("#menu").css("width", $(".main").length * 100)
    //  一進入畫面時收合選單
    $(".sub").slideUp(0);

    for (i = 0; i < $(".main").length; i++) {
        //  點選按扭時收合或展開選單
        $(".main:eq(" + i + ")").on("mouseover", {
            id: i
        }, function (e) {
            n = e.data.id
            $(".sub:eq(" + n + ")").slideToggle()
            $(".sub:not(:eq(" + n + "))").slideUp()
            $(".main:eq(" + n + ")").text(newtext[n])
        })
        $(".main:eq(" + i + ")").on("mouseleave", {
            id: i
        }, function (e) {
            n = e.data.id
            $(".main:eq(" + n + ")").text(oldtext[n])
            $(".sub").stop();
        })
    }
})

