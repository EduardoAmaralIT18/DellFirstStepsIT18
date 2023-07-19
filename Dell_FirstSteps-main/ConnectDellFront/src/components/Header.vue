<script setup lang="ts">

const props = defineProps({role:Number, name:String})

function showRole() {
      if ((props.role=== 0)) {
        return "Admin";
      } else if ((props.role === 1)){
          return "Intern";
      } else if ((props.role=== 2)){
          return "Dell Manager";
      } else if ((props.role === 3)){
          return "Dell Member";
      } else if ((props.role === 4)){
          return "Dell Pucrs Staff";
      }
    }
</script>


<template>
    <header class="navbar shadow-lg fixed-top">
        <div class="container-fluid">
            <div class="row">
                <div class="col-4 dellLogo">
                  <a>
                    <span class="icon dds__icon dds__icon--brand-delltechnologies"> </span>
                  </a>
                </div>
                <div class="col-8">
                <nav class="userName">
                    <div class="d-none d-lg-block">
                      <p class="name"> {{ name }} | {{ showRole() }}<svg class="dds__icon dds__icon--user" aria-hidden="true"><use xlink:href="#dds__icon--user" /></svg></p>
                    </div>
                  </nav>            
                </div>
  
            </div>
        </div>
    </header>
  </template>
  
  <style>
    .navbar{
      padding-bottom: 0;
      margin-bottom: 0;
      background-color: #ffffff;
      box-shadow: 2px 2px #a6a6a6ba;
      width: 100%;
      border-bottom: 2px solid #A6A6A6;
      margin-bottom: 0;
      width: 100%;
      height: 75px;
      display: flex ;
      vertical-align: center;
      padding-top: 3px; 
    }
    .name{
      color: #0672CB;
      font-size: 151%;
      position: absolute;
      right: 0;
      top:0;
       margin-top: 10px; 
      margin-right: 1%;
    }
    .userPicture{
      width: 47px;
      margin-left: 1px;
      margin-bottom: 3%; 
      padding-top: 4px; 
    }
    .icon{
      font-size: 13em;
      background-color: #0672CB;
      margin-left: 3%;
      padding: 10;  
      position: relative;
      line-height: 0.2em;
    }
  </style>
  
