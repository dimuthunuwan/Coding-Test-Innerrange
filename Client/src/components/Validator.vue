<script setup>
  import {ref} from 'vue'
import { VueTable  } from "@harv46/vue-table"
import "@harv46/vue-table/dist/style.css"

const headers = ["Name", "State", "Salary", "DOB", "PostCode","IsNameValid","IsPostCodeValid",
                  "IsStateValid","IsSalaryValid","IsPostCodeExist","IsPostCodeBelongsToState"];
const keyValue = [
        "name",
        "state",
        "salary",
        "dob",
        "postcode",
        "isnamevalid",
        "ispostcodevalid",
        "isstatevalid",
        "issalaryvalid",
        "ispostcodeexist",
        "ispostcodebelongstostate",
    ];



  const csvFile = ref();
  const stateFile = ref();
  const pagedData = ref({
    totalPages: 0,
    currentPage: 1,
    pageSize: 25,
  })

  const onCsvFileChange = (e) =>{ 
    csvFile.value = e.target.files[0];
  }

  const onStateFileChange = (e) =>{
    stateFile.value = e.target.files[0];
  }

  const onValidate = ()=>{
    let data = new FormData();
    data.append('csvFile', csvFile.value);
    data.append('stateFile', stateFile.value);
    
    fetch('/validator/validate', {
      method: "POST",
      body: data,
    })
    .then(response => response.json())
    .then(data =>{console.log(data); 
    return data  } )
  }

  const onNextPage = () =>{
    fetch('/validator/getPagedData', {
      method: "POST",
      headers:{ 'Content-Type': 'application/json' },
      body: JSON.stringify({ 
        page: pagedData.value.currentPage, 
        pageSize: pagedData.value.pageSize 
      })
    })
    .then(response => response.json())
    .then(data => {

    })
  }
</script>

<template>
  <div>
    <form>
      <label for="csvFile">CSV To Validate </label>
      <input id="csvFile" name="csvFile" type="file" @change="onCsvFileChange">
      <br>
      <label for="stateFile">States File </label>
      <input id="stateFile" name="stateFile" type="file" @change="onStateFileChange">
      <br>
      <button type="button" @click="onValidate">Validate</button>
    </form>
  </div >
  <div class="result">
    Output result in tabular format

    <VueTable :headers="headers" :keys="keyValue" :data="onValidate">
        <template #th>
            <th> Actions</th>
        </template>
        <template #td="{ item }">
            {/* item will be the object in a row */}
            <td class="flex">
                <DeleteIcon @click="deleteItem(item.id)" />
                <EditIcon @click="edit(item)" />
            </td>
        </template>
    </VueTable>
  </div>
  <div>
    <button @click="onNextPage">Next Page</button> 
    <button>Previous Page</button>
  </div>
</template>

<style scoped>
.result {
  border: 1px solid lightgray;
  
  padding: 4px;
  margin: 4px;
}
</style>
