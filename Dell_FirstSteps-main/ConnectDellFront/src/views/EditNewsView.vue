<script setup lang="ts">


import { onMounted, ref } from "vue";
import type Program from "@/interfaces/Program";
import type News from "@/interfaces/News";
import axios from "axios";
import TextInput from "@/components/TextInput.vue";
import TextArea from "@/components/TextArea.vue";
import PrimaryButton from "@/components/PrimaryButton.vue";
import FileInput from "@/components/FileInput.vue";
import GoBackButton from "@/components/GoBackButton.vue";
import { useRoute } from "vue-router";
import router from "@/router";



const programList = ref<Program[]>([]);

const role = ref(+localStorage.getItem('userRole')!).value;
const author = ref(+localStorage.getItem('userId')!).value;
const route = useRoute();
const newsId = +route.params.id;

const newsToBeUpdated = ref<News>({
  id: 0,
  title: '',
  text: '',
  program: '',
  programId: 0,
  author: '',
  authorId: 0,
  image: '',
  date: ''
});

onMounted(async () => {
  await getNews(newsId);
  await getPrograms(author, role);


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
  if ("title" in newsToBeUpdated.value!) {
    newsToBeUpdated.value.title = title;
  }
}
const handleText = (text: string) => {
  if ("text" in newsToBeUpdated.value!) {
    newsToBeUpdated.value.text = text;
  }
}

const disableButton = () => {
  if (newsToBeUpdated.value!.title.trim().length > 5 &&
    newsToBeUpdated.value!.text.trim().length > 5 &&
    newsToBeUpdated.value!.programId > 0) {
    return false;
  }
  return true;
}

const selectedFile = ref<File | null>(null);

const onFileChange = (file: File) => {
  selectedFile.value = file
};

const zeroStates = () => {
  newsToBeUpdated.value!.title = '';
  handleText('');
  newsToBeUpdated.value!.programId = 0;
  selectedFile.value = null;
}
const submitForm = () => {
  const formData = new FormData();
  formData.append('id', newsToBeUpdated.value!.id.toString());
  formData.append('image', selectedFile.value!);
  formData.append('title', newsToBeUpdated.value!.title);
  formData.append('author', newsToBeUpdated.value!.authorId.toString());
  formData.append('program', newsToBeUpdated.value!.programId.toString());
  formData.append('text', newsToBeUpdated.value!.text);
  if (selectedFile.value !== null) {
    formData.append('imageName', selectedFile.value!.name);
  }
  console.log(newsToBeUpdated.value)

  axios
    .patch(`https://localhost:5001/News/updateNews`, formData, {
      headers: {
        'Content-Type': 'multipart/form-data',
      },
    })
    .then((response) => {
      zeroStates()
      alert('Notícia alterada com sucesso.')
      router.push("/news")
    })
    .catch((error) => {
      console.error('Erro ao enviar a imagem:', error);
    });

}

</script>

<template>
  <div class="container">
    <GoBackButton class="button" path="/news" />
    <h2 class="title">Manage News</h2>
    <form v-if="newsToBeUpdated" @submit="submitForm">
      <label for="program" class="dds__label dds__label--required">Program</label>
      <select name="program" v-model="newsToBeUpdated.programId" required>
        <option :selected="newsToBeUpdated.programId == program.id" :value="program.id" :key="program.id"
          v-for="program in programList">
          {{ program.name }}
        </option>
      </select>
      <TextInput :initial-value="newsToBeUpdated.title" @typedText="handleTitle" boxName="Title"></TextInput>
      <TextArea :initial-value="newsToBeUpdated.text" @descriptionText="handleText" boxName="Text"></TextArea>
      <FileInput :image-name="`Limit 2MB - PNG or JPG accepted.`" @fileSelected="onFileChange"></FileInput>
      <PrimaryButton buttonName="Submit" :disabled="disableButton()" @clicked="submitForm" />
      <!-- <PrimaryButton buttonName="Submit" @clicked="submitForm"/> -->
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