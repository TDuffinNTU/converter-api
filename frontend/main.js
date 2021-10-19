// refresh on load
window.onload = refresh();

// get api data and call fill selects/table methods
function refresh() 
{
    fetch('https://localhost:5001/Money',
    {
        headers: {
        'Content-Type': 'application/json',
    }}) 
    .then(response => {
        return response.json();
    })
    .then(json => 
    {
        fill_table(json);
        fill_selects(json);
    })
}

// fills table with json obj
function fill_table(obj)
{
    var table = document.getElementById("table");
    table.innerHTML = '';   
      
    obj.currencyPairs.forEach(function(pair)
    {        
        // creating table data/row
        var new_row = document.createElement('tr');    

        new_row.innerHTML = `<td class="col-md-1">${pair.base.symbol} ${pair.base.iso}</td>
                            <td class="col-md-3">${pair.value}</td>
                            <td class="col-md-1">${pair.quote.symbol} ${pair.quote.iso}</td>`

        table.appendChild(new_row);        
    });
}

// fills selects with json obj
function fill_selects(obj)
{
    var elements = Array.from(document.getElementsByTagName("select"));
    console.log(elements);   

    // create options
    var new_options = '<option value="">Select Quote</option>';
    obj.currencies.forEach(currency => {
         new_options += `<option value="${currency.iso}">(${currency.iso}) ${currency.symbol}</option>`;  
    });

    // set options
    elements.forEach(el => {
        el.innerHTML = new_options;
    }); 
}

function set_autorefresh(opt)
{
    // set option here!
}

function submit() 
{
    alert("submit");
}