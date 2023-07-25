<script setup lang="ts">


import {onMounted, ref} from "vue";
import type Program from "@/interfaces/Program";
import type News from "@/interfaces/News";
import axios from "axios";
import router from "@/router"
import TextInput from "@/components/TextInput.vue";
import TextArea from "@/components/TextArea.vue";
import PrimaryButton from "@/components/PrimaryButton.vue";
import type AddNews from "@/interfaces/AddNews";
const programList = ref<Program[]>([]);
const newsToBeCreated = ref<AddNews>(
    {
      author: 0, program: 0, text: "", title: ""
    }
);

const role = ref(+localStorage.getItem('userRole')!).value;
const author = ref(+localStorage.getItem('userId')!).value;

onMounted(async () => {
  await getPrograms(author, role);
  newsToBeCreated.value.author = author;
})

const getPrograms = async (userId: number, role: number) => {
  await axios
      .get(`https://localhost:5001/Program/getPrograms?idUser=${userId}&role=${role}`)
      .then((response) => {
        programList.value = response.data.myPrograms;
      }).catch((e) => {
        console.error(e);
      })
}

const addNews = async (news: AddNews) => {
  await axios
      .post(`https://localhost:5001/News/addContent`, news)
      .then((response) => {
        console.log(response.data)
      }).catch((e) => {
        console.error(e);
      })
}

const handleTitle = (title : string) => {
  newsToBeCreated.value.title = title.trim();
}
const handleText = (text : string) => {
  newsToBeCreated.value.text = text;
}

const disableButton = () =>  {
  console.log(newsToBeCreated.value.title?.trim().length, newsToBeCreated.value.text?.trim().length, newsToBeCreated.value.program)
   return !(newsToBeCreated.value.title?.trim().length > 5 && newsToBeCreated.value.text?.trim().length > 5  && newsToBeCreated.value.program > 0)
}



</script>

<template>
  <form>
    <label for="program">Program</label>
    <select name="program" v-model="newsToBeCreated.program" required>
      <option :value="program.id" :key="program.id" v-for="program in programList">
        {{ program.name }}
      </option>
    </select>
    <TextInput @typedText="handleTitle"  boxName="Title"></TextInput>
    <TextArea @descriptionText="handleText"  boxName="Text"></TextArea>
    <PrimaryButton buttonName="Submit" :isDisabled="disableButton()" @clicked="addNews(newsToBeCreated)"/>
  </form>
</template>

<style scoped lang="scss">
form {
  display: flex;
  flex-direction: column;
}
</style>