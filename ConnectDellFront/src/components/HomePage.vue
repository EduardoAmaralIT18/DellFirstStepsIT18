<template>
    <div class="container">
        <h4 class="title">
            Welcome, {{ user.name }}!
        </h4>

        <div v-if="myPrograms && myPrograms.length > 0">
            <h4 class="subtitle">
                My Programs
            </h4>
            <div class="row">
                <div class="col-2 dds__mr-4 dds__mb-3" v-for="(item, i) in myPrograms" :key="i">
                    <div class="flip-card" tabindex="0">
                        <div class="flip-card-inner">
                            <div class="flip-card-front">
                                <div class="dds__card__content">
                                    <div class="dds__card__header">
                                        <div class="dds__card__header__text">
                                            <h5 class="dds__card__header__title">{{ item.name }}</h5>
                                    </div>
                                </div>
                            </div>
                    </div>
                    <div class="flip-card-back">
                        <div class="dds__card__body">{{ item.description }}</div>
                                    <div class="dds__card__footer">
                                    </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                            </div>
                    </div>

        <div v-if="(programs && programs.length > 0) || IsAdmin">
            <h4 class="subtitle">
                Programs
            </h4>
            <div class="row">
                <div class="col-2 dds__mr-4 dds__mb-4" v-for="(item, i) in programs" :key="i">
                    <div class="flip-card">
                        <div class="flip-card-inner">
                            <div class="flip-card-front">
                                <div class="dds__card__content">
                                    <div class="dds__card__header">
                                        <div class="dds__card__header_text">
                                            <h5 class="dds__card__header__title">{{ item.name }}</h5>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="flip-card-back">
                                <div class="dds__card__body">{{ item.description }}</div>
                                    <div class="dds__card__footer">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-2 dds__mr-4 dds__mb-4" v-if="IsAdmin">
                    <div class="flip-card">
                            <div class="flip-card-back">
                                <div class="dds__card__content">
                            <div class="dds__card__body">
                                <button class="dds__button dds__button__icon" type="button">
                                    <i class="dds__icon dds__icon--plus-add dds__card__header__icon"
                                    title="Add a Program"></i>
                                </button>
                        </div>
                            </div>
                            </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    name: 'HelloWorld',
    props: {
    },
    data() {
        return {
            user: {
                "name": "Jordana",
                "role": "Admin"
            },
            myPrograms: [
                {
                    "name": "IT Academy 2",
                    "description": "Description IT"
                },
                {
                    "name": "Design Academy 2",
                    "description": "Description Design"
                },
                {
                    "name": "Infrastructure Residency 2",
                    "description": "Description Infra"
                }
            ],
            programs: [
            {

"name": "IT Academy",

"description": "Description IT"

},

{

"name": "Design Academy",

"description": "Description Design"

}

]

}

},
    computed: {
        IsAdmin() {
            return this.user.role === 'Admin';
        }
    }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.container {
    padding-top: 5%;
    padding-left: 15%;
    display: inline-flex;
    flex-direction: column;
}
.dds__card {
    width: 12rem;
    color: #0672CB;
    box-shadow: 5px 5px lightgrey;
    border-radius: 10px;
    transition: transform 0.6s;
    transform-style: preserve-3d;
}
.dds__card__header__title {
    font-weight: 550;
    color: #0672CB;
    text-align: center;
    
}
.dds__card__body {
    color: #0672CB;
}
.title {
    margin-left: 4.0% !important;
    text-align: left;
    color: #0672CB;
    margin: 2.5%;
    font-weight: bold;
}
.subtitle {
    margin-left: 4.0% !important;
    text-align: left;
    color: #0672CB;
    margin: 2.5%;
    font-weight: bold;
}
.dds__button {
    background-color: white;
    border-style: none;
}
.dds__button:hover {
    background-color: unset !important;
}
.dds__icon {
    color: #0672CB;
    font-size: 55px;
    font-weight: bold;
}

.flip-card {
        position: relative;
width: 10rem;
height: 8rem;
border-radius: 10px;
text-align: center;
transition: transform 0.6s;
transform-style: preserve-3d;
backface-visibility: hidden;
-moz-backface-visibility: hidden;
margin: 1cm;
}

.flip-card-inner {
        position: relative;
        width: 100%;
        height: 100%;
        text-align: center;
        transition: transform 0.6s;
        transform-style: preserve-3d;
        backface-visibility: hidden;
            border-radius: 10px;
        -moz-backface-visibility: hidden;
      }

      .flip-card:focus {
          outline: 0;
      }

      .flip-card:hover .flip-card-inner,
      .flip-card:focus .flip-card-inner{
        transform: rotateY(180deg);
            border-radius: 10px;
      }

      .flip-card-front,
      .flip-card-back {
        position: absolute;
        width: 100%;
        border-radius: 10px;
        height: 100%;
      }

      .flip-card-front {
  background-color: white;
        z-index: 2;
        display: flex;
        justify-content: center;
        align-items: center;
      }

      .flip-card-back {
  background-color: white;
        transform: rotateY(180deg);
        z-index: 1;
        display: flex;
        justify-content: center;
        align-items: center;
          box-shadow: -5px 5px 0px 0px lightgrey;
      }
</style>  