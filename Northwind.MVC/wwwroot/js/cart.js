$(document).ready(function () {



    $.ajax({
        url: "https://localhost:7214/api/cart/getitems",
        type: "get",
        xhrFields: {
            withCredentials: true
        },
        success: function (data) {
            console.log(data);
            fillCartTable(data);
        },
        error: function (err) {
            console.log(err);
        }
        })




    $("#productTableBody").on("click", function (e) {
        if (e.target.name = "addtocart") {
         
            addToCart(e.target.id);
        }
    })


    function addToCart(id) {
        $.ajax({
            url: "https://localhost:7214/api/cart/addtocart/" + id,
            xhrFields: {
                withCredentials: true
                },
            type: "get",
            success: function (data) {
                console.log(data);
                alert(data.productName + " sepete eklendi!");
            },
            error: function (err) {
                console.log(err);
            }
            })
    }

    // Silme İşlemi
    $("${val.id}").on("click", function (e) {
        if (e.target.name = "removeitem")
        {
            deleteToCart(e.target.id);
        }
    })

    function deleteToCart(id) {
        $.ajax({
            url: "https://localhost:7214/api/cart/DeleteItems/" + id,
            xhrFields: {
                withCredentials: true
            },
            type: "delete",
            success: function (data) {
                alert("Kart Silindi");
                console.log(data)                
            },
            error: function (err) {
                console.log(err);
            }
        })
    }

    // Update İşlemi
    $("${val.id}").on("click", function (e) {
        if (e.target.name = "cartquantity") {
            updateToCart(e.target.id);
        }
    })

    function updateToCart(id) {
        $.ajax({
            url: "https://localhost:7214/api/cart/UpdateItems/" + id,
            xhrFields: {
                withCredentials: true
            },
            type: "put",
            success: function (data) {
                alert("Kart Güncellendi");
                console.log(data)
            },
            error: function (err) {
                console.log(err);
            }
        })
    }

    function fillCartTable(items) {
        var totalPrice = 0;
        const cartTableBody = $("#cartTableBody");
        items.map(function (val, index) {
            totalPrice += val.subTotal;
            const tr = `
                <tr>
<td>${val.productName}</td>
<td>${val.unitPrice}</td>
<td>
<input class="form-control" type="number" value=${val.quantity} name="cartquantity" id=${val.id} />

</td>
<td>${val.subTotal}</td>
<td>
<button class="btn btn-sm btn-danger" name="removeitem" id=${val.id}>Remove</button>
</td>



</tr>

`
            cartTableBody.append(tr);
        })

        $("#totalPrice").text(totalPrice + "₺");
    }





})