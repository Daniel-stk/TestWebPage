$(function () {
    if('@ViewBag.Success'){
        Materialize.toast('@ViewBag.Success', 3000, 'success')
    } if ('@ViewBag.Failed') {
        Materialize.toast('@ViewBag.Failed', 3000, 'danger')
    }
});