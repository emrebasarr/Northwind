$(document).ready(function () {

    //Get Product
    function getProducts() {
        $.ajax({
            url: "https://localhost:7214/api/product",
            type: "get",
            success: function (data) {
                console.log(data);
                fillTableProductData(data)
            },
            error: function (err) {
                console.log(err);
            }

        })
    }

    //fill table
    function fillTableProductData(products) {
        const productTableBody = $("#productTableBody");

        products.map(function (val, i) {
            const tr = `
                    <tr>
<td>${val.productId}</td>
<td>${val.productName}</td>
<td>${val.unitPrice}</td>
<td>${val.unitsInStock}</td>
<td>${val.category.categoryName}</td>
<td>${val.supplier.companyName}</td>
<td>
<button class="btn btn-sm btn-primary" name="addtocart" id=${val.productId}>Add To Cart</button>
</td>



</tr>
`;

            productTableBody.append(tr);
        })
    }



    getProducts();



})