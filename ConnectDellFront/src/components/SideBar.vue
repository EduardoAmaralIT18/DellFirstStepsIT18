<script lang="ts">
import { defineComponent } from 'vue';
import { RouterLink, RouterView } from 'vue-router';

export default defineComponent({
  name: 'SideBar',
  components: {
    RouterLink,
    RouterView
  },
  data() {
      return {}
  }
})

//comentario teste
</script>


<template> 
    <div class="sidenav d-none d-lg-block">
<<<<<<< HEAD
        <RouterLink to="/home" :class="{onViewEffect: homeView}" class="hoverEffect hovicon effect-1 sub-a"><img class="smallIcons" alt="home icon" src="../assets/home.png">
=======
        <RouterLink to="/logged" class="hoverEffect hovicon effect-1 sub-a"><img class="smallIcons" alt="home icon" src="../assets/home.png">
>>>>>>> f2324de1307558d1487dcc112ccadc2e854aa3e5
        Home</RouterLink>

        <RouterLink to="/users" class="hoverEffect hovicon effect-1 sub-a"><img class="smallIcons" alt="user icon" src="../assets/user.png">Users</RouterLink>

        <RouterLink to="/news" class="hoverEffect hovicon effect-1 sub-a"><img class="smallIcons" alt="news icon" src="../assets/news.png">News</RouterLink>

    </div>

    <div class="smallSidenav d-lg-none"> 
<<<<<<< HEAD
      <RouterLink to="/home" :class="{onViewEffect: homeView}" class="hoverEffect hovicon effect-1 sub-a"><img class="smallIcons" alt="home icon" src="../assets/home.png">
=======
      <RouterLink to="/logged" class="hoverEffect hovicon effect-1 sub-a"><img class="smallIcons" alt="home icon" src="../assets/home.png">
>>>>>>> f2324de1307558d1487dcc112ccadc2e854aa3e5
        <br></RouterLink>
      <RouterLink to="/users" class="hoverEffect hovicon effect-1 sub-a"><img class="smallIcons" alt="user icon" src="../assets/user.png">
        <br></RouterLink>
      <RouterLink to="/news" class="hoverEffect hovicon effect-1 sub-a" ><img class="smallIcons" alt="news icon" src="../assets/news.png">
        <br></RouterLink>
    </div>

    <RouterView/>
  </template>
  
  <style scoped>
  .smallIcons {
    width: 48px;
    margin-bottom: 3%;
  }
  
  .sidenav{
    height: 100%;
    /* Full-height: remove this if you want "auto" height */
    width: 17%;
    /* Set the width of the sidebar */
    position: fixed;
    /* Fixed Sidebar (stay in place on scroll) */
    top: 0;
    bottom: 0;
    left: 0;
    background-color: #ffffff;
    overflow-x: hidden;
    /* Disable horizontal scroll */
    padding-top: 140px;
    border-right: 1px solid #b9b8b8;
  }
  
  .smallSidenav{
    height: 100%;
    /* Full-height: remove this if you want "auto" height */
    width: 17%;
    /* Set the width of the sidebar */
    position: fixed;
    /* Fixed Sidebar (stay in place on scroll) */
    height: 100%;
    top: 0;
    bottom: 0;
    left: 0;
    background-color: #ffffff;
    overflow-x: hidden;
    /* Disable horizontal scroll */
    padding-top: 140px;
    border-right: 1px solid #b9b8b8;
  }

  /* The navigation menu links */
  .hoverEffect{
    border-right: 20%;
    border-bottom: 20%;
    border-top: 20%;
    text-decoration: none;
    font-size: 20px;
    color: #0672CB;
    margin-bottom: 6%;
    float: left;
    width: 100%;
    text-align: left;
    padding-left: 4%;
  }
  
  .router-link-exact-active {
  background:#f4f1f1;
  border-left: 10px solid #0672CB;

}


  /* When you mouse over the navigation links, change their color */
  .hoverEffect:hover{
    background:#f4f1f1;
    border-left: 10px solid #0672CB;
    width: 100%;
  }

  
  /* On smaller screens, where height is less than 450px, change the style of the sidebar (less padding and a smaller font size) */
  @media screen and (max-height: 450px) {
    .sidenav {
      padding-top: 15px;
    }
  
    .hoverEffect{
      margin-top: 40%;
      font-size: 20px;
      margin-bottom: 38%;
      padding-left: 24%;
      width: 100%;
    }
  }
  
  .hoverEffect:active{
    background: #c6c6c6;
    color: #0672CB;
    box-shadow: 0 0 0 8px #cac9c9a3;
  }
  </style>