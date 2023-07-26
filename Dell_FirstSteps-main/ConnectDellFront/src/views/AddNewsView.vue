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
import FileInput from "@/components/FileInput.vue";
import GoBackButton from "@/components/GoBackButton.vue";

const programList = ref<Program[]>([]);
const newsToBeCreated = ref<AddNews>(
    {
      author: 0, program: 0, text: "", title: "", imageName: ''
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

const handleTitle = (title: string) => {
  newsToBeCreated.value.title = title.trim();
}
const handleText = (text: string) => {
  newsToBeCreated.value.text = text;
}

const disableButton = () => {
  console.log(newsToBeCreated.value.title?.trim().length, newsToBeCreated.value.text?.trim().length, newsToBeCreated.value.program)
  return !(newsToBeCreated.value.title?.trim().length > 5 && newsToBeCreated.value.text?.trim().length > 5 && newsToBeCreated.value.program > 0)
}

const selectedFile = ref<File | null>(null);

const onFileChange = (file: File, name: String) => {
  selectedFile.value = file
  newsToBeCreated.value.imageName = name
};
const submitForm = () => {
  if (selectedFile.value) {
    const formData = new FormData();
    formData.append('image', selectedFile.value!);
    formData.append('title', newsToBeCreated.value.title);
    formData.append('author', newsToBeCreated.value.author.toString());
    formData.append('program', newsToBeCreated.value.program.toString());
    formData.append('text', newsToBeCreated.value.text);
    formData.append('imageName', newsToBeCreated.value.imageName!);

    axios
        .post(`https://localhost:5001/News/addContent`, formData, {
          headers: {
            'Content-Type': 'multipart/form-data',
          },
        })
        .then((response) => {
          console.log('Imagem enviada com sucesso!', response);
        })
        .catch((error) => {
          console.error('Erro ao enviar a imagem:', error);
        });
  }
}

</script>

<template>
  <div class="container">
    <GoBackButton class="button" path="/news"/>
    <h2 class="title">Add News</h2>
    <form @submit="submitForm">
      <label for="program" class="dds__label dds__label--required">Program</label>
      <select name="program" v-model="newsToBeCreated.program" required>
        <option :value="program.id" :key="program.id" v-for="program in programList">
          {{ program.name }}
        </option>
      </select>
      <TextInput @typedText="handleTitle" boxName="Title"></TextInput>
      <TextArea @descriptionText="handleText" boxName="Text"></TextArea>
      <FileInput @fileSelected="onFileChange"></FileInput>
      <PrimaryButton buttonName="Submit" :isDisabled="disableButton()" @clicked="submitForm"/>
    </form>
  </div>
</template>

<style scoped lang="scss">
.title {
  color: #0063B8;
  font-size: 200%;
  font-weight: 500;
  text-align: center;
}

.container {
  padding: 5% 20% 50vh 20%;
  display: flex;
  flex-direction: column;
  overflow-x: auto;

  form {
    margin-top: 30px;
    display: flex;
    flex-direction: column;
    gap: 10px;

    button {
      margin-top: 1rem
    }

    select {
      height: 48px;
    }

  }
}


</style>