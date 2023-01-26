<template>

    <div class="container">

        <h4 class="title">
            {edition.name} - Members
        </h4>

        <div role="table" id="table-345548026" data-dds="table" class="dds__table"></div>

    </div>

</template>


<script lang="ts"> //mudar pra JS? 

const columns = [{ "value": "Name", "sortBy": "ascending" }, { "value": "E-mail" }, { "value": "Role" }];
const data = [
    [{ "value": "Row 1" }, { "value": "Row 1" }, { "value": "Row 1" }],
    [{ "value": "Row 2" }, { "value": "Row 2" }, { "value": "Row 2" }],
    [{ "value": "Row 3" }, { "value": "Row 3" }, { "value": "Row 3" }],
    [{ "value": "Row 4" }, { "value": "Row 4" }, { "value": "Row 4" }],
    [{ "value": "Row 5" }, { "value": "Row 5" }, { "value": "Row 5" }]
];
DDS.Table(document.getElementById("#table-345548026"), {
    data,
    columns,
});

</script>

<style scooped>

body {
    font-family: 'Roboto', sans-serif;
}

.container {
    padding-top: 5%;
    padding-left: 15%;
    display: inline-flex;
    flex-direction: column;
}

.title {
    margin-left: 0px !important;
    text-align: left;
    color: #0672CB;
    margin: 2.5%;
    font-weight: bold;
}

</style>