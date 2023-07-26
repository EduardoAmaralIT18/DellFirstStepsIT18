<script setup lang="ts">


import {onMounted, ref} from "vue";
import type Program from "@/interfaces/Program";
import type News from "@/interfaces/News";
import axios from "axios";
import TextInput from "@/components/TextInput.vue";
import TextArea from "@/components/TextArea.vue";
import PrimaryButton from "@/components/PrimaryButton.vue";
import type AddNews from "@/interfaces/AddNews";
import FileInput from "@/components/FileInput.vue";
import GoBackButton from "@/components/GoBackButton.vue";
import { useRoute } from "vue-router";

const programList = ref<Program[]>([]);

const role = ref(+localStorage.getItem('userRole')!).value;
const author = ref(+localStorage.getItem('userId')!).value;

const imageName = ref<string>('Limit 2MB - PNG or JPG accepted.');

const route = useRoute();
const newsId = +route.params.id;

const newsToBeUpdated = ref<News>({
    id: 0,
    programId: 0,
    authorId: 0,
    title: '',
    text: '',
    program: '',
    author: '',
    date: ''
});

onMounted(async () => {
  await getNews(newsId);
  await getPrograms(author, role);
  console.log(newsToBeUpdated.value.title)
})

const getNews = async (newsId: number) => {
  await axios
        .get(`https://localhost:5001/News/getSpecificNews?id=${newsId}`)
        .then((response) => {
            newsToBeUpdated.value = response.data
        }).catch((e) => {
            console.error(e);
        })
}

const getPrograms = async (userId: number, role: number) => {
  await axios
      .get(`https://localhost:5001/Program/getPrograms?idUser=${userId}&role=${role}`)
      .then((response) => {
        programList.value = response.data.myPrograms;
      }).catch((e) => {
        console.error(e);
      })
}

const handleTitle = (title: string) => {
  newsToBeUpdated.value.title = title;
}
const handleText = (text: string) => {
  newsToBeUpdated.value.text = text;
}

const disableButton = () => {
  if(newsToBeUpdated.value.title?.trim().length > 5 && newsToBeUpdated.value.text?.trim().length > 5 && newsToBeUpdated.value.program > 0){
    return false
  }
  return true
}

const selectedFile = ref<File | null>(null);

const onFileChange = (file: File) => {
  selectedFile.value = file
  newsToBeUpdated.value.imageName = file.name
};

const zeroStates = () => {
  newsToBeUpdated.value.title = '';
  handleText('')
  newsToBeUpdated.value.imageName = '';
  newsToBeUpdated.value.program = 0;
  newsToBeUpdated.value.author = 0;
  selectedFile.value = null;
}
const submitForm = () => {
  const formData = new FormData();
  formData.append('image', selectedFile.value!);
  formData.append('title', newsToBeUpdated.value.title);
  formData.append('author', newsToBeUpdated.value.author.toString());
  formData.append('program', newsToBeUpdated.value.program.toString());
  formData.append('text', newsToBeUpdated.value.text);
  formData.append('imageName', newsToBeUpdated.value.imageName!);

  axios
      .patch(`https://localhost:5001/News/updateNews`, formData, {
        headers: {
          'Content-Type': 'multipart/form-data',
        },
      })
      .then((response) => {
        zeroStates()
        alert('Notícia adicionada com sucesso')
      })
      .catch((error) => {
        console.error('Erro ao enviar a imagem:', error);
      });

}

</script>

<template>
  <div class="container">
    <GoBackButton class="button" path="/news"/>
    <h2 class="title">Manage News</h2>
    <form @submit="submitForm">
      <label for="program" class="dds__label dds__label--required">Program</label>
      <select name="program" v-model="newsToBeUpdated.program" required>
        <option :value="program.id" :key="program.id" v-for="program in programList">
          {{ program.name }}
        </option>
      </select>
      <TextInput @typedText="handleTitle" boxName="Title"></TextInput>
      <TextArea @descriptionText="handleText" boxName="Text"></TextArea>
      <FileInput :image-name="newsToBeUpdated.imageName ? newsToBeUpdated.imageName : `Limit 2MB - PNG or JPG accepted.`" @fileSelected="onFileChange"></FileInput>
      <PrimaryButton buttonName="Submit" :disabled="disableButton()" @clicked="submitForm"/>
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