var app = app || {};
(function (n) {
    var t = [];
    app.modals = app.modals || {};
    app.ModalManager = function () {
        function i(t) {
            var r = t + "Container",
            u = "#" + r,
            i = $(u);
            i.length && i.remove()
        }
        function u(t) {
            i(t);
            var r = t + "Container";
            return $('<div id="' + r + '"><\/div>').append('<div id="' + t + '" class="modal fade" tabindex="-1" role="modal" aria-hidden="true">  <div class="modal-dialog">    <div class="modal-content"><\/div>  <\/div><\/div>').appendTo("body")
        }
        var r = function (n) {
            n.modalId || (n.modalId = "Modal_" + Math.floor(Math.random() * 1e6) + (new Date).getTime())
        };
        return function (f) {
            function a() {
                o && o.save && o.save()
            }
            function v() {
                e = $(p);
                e.modal({
                    backdrop: "static"
                });
                e.on("hidden.bs.modal",
                function () {
                    i(h)
                });
                e.on("shown.bs.modal",
                function () {
                    e.find("input:first").focus()
                });
                var t = app.modals[f.modalClass];
                t && (o = new t, o.init && o.init(l, s));
                e.find(".save-button").click(function () {
                    a()
                });
                e.find(".modal-body").keydown(function (n) {
                    n.which == 13 && (n.preventDefault(), a())
                });
                e.modal("show")
            }
            function w(n) {
                e && e.find(".modal-footer button").buttonBusy(n)
            }
            var c, y;
            r(f);
            var e = null,
            h = f.modalId,
            p = "#" + h,
            o = null,
            l = null,
            s = null;
            return c = function (i) {
                s = i || {};
                u(h).find(".modal-content").load(f.viewUrl, s,
                function (i, r) {
                    if (r == "error") {
                        abp.message.warn('InternalServerError');
                        return
                    }
                    v()
                    //f.scriptUrl && _.indexOf(t, f.scriptUrl) < 0 ? n.getScript(f.scriptUrl).done(function () {
                    //    t.push(f.scriptUrl);
                    //    v()
                    //}).fail(function () {
                    //    abp.message.warn('scriptUrlInternalServerError')
                    //}) : v()
                })
            },
            y = function () {
                e && e.modal("hide")
            },
            l = {
                open: c,
                reopen: function () {
                    c(s)
                },
                close: y,
                getModalId: function () {
                    return h
                },
                getModal: function () {
                    return e
                },
                getArgs: function () {
                    return s
                },
                setBusy: w
            }
        }
    }()
})(jQuery);