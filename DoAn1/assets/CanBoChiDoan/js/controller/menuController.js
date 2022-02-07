var sanpham = {
    init: function () {
        sanpham.registerEvents();
    },
    registerEvents: function () {
        $('.btn-block').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            $.ajax(
                {
                    url: "/SV_HoatDong/ChangeStatus",
                    data: { id: id },
                    datatype: "json",
                    type: "POST",
                    success: function (response) {
                        console.log(response);
                        if (response.status == false) {
                            btn.text('Duyệt');
                        } else {
                            btn.text('Bỏ duyệt');
                        }
                    }
                });
        });
    }
}
sanpham.init();