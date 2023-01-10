<template>
    <div class="container">
        <div class="teste">
            <h2>News</h2>
            <button class="dds__button dds__button--secondary" type="button">Secondary Button</button>
        </div>
        <div class="dds__col-12 dds__col--md-6 dds__col--lg-4 dds__mb-3" id="card-news">
            <div class="dds__card">
                <div class="dds__card__content">
                    <div class="dds__card__header">
                        <i class="dds__icon dds__icon--accessibility dds__card__header__icon"></i>
                        <span class="dds__card__header__text">
                            <h5 class="dds__card__header__title">Card Title</h5>
                            <span class="dds__card__header__subtitle">Optional Subtitle</span>
                        </span>
                    </div>
                    <div class="dds__card__body">Description text should not exceed more than a few lines.</div>
                    <div class="dds__card__footer">
                        <button class="dds__button dds__button--sm dds__card__footer__item" type="button"
                            aria-describedby="card  Primary">Primary</button>
                        <button class="dds__button dds__button--secondary dds__button--sm dds__card__footer__item"
                            type="button" aria-describedby="card  Secondary">
                            Secondary
                        </button>
                    </div>
                </div>
            </div>
        </div>
        <div class="dds__col-12 dds__col--md-6 dds__col--lg-4 dds__mb-3" id="card-news">
            <div class="dds__card">
                <div class="dds__card__media">
                    <img src="https://i.dell.com/sites/csimages/Learn_Imagery/all/565x363-services-splitter-3.jpg"
                        alt="A person at a desk using a laptop" />
                </div>
                <div class="dds__card__content">
                    <div class="dds__card__header">
                        <i class="dds__icon dds__icon--accessibility dds__card__header__icon"></i>
                        <span class="dds__card__header__text">
                            <h5 class="dds__card__header__title">Card Title</h5>
                            <span class="dds__card__header__subtitle">Optional Subtitle</span>
                        </span>
                    </div>
                    <div class="dds__card__body">Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod
                        tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
                        exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in
                        reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint
                        occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
                    </div>
                    <div class="dds__card__footer">
                        <button class="dds__button dds__button--sm dds__card__footer__item" type="button"
                            aria-describedby="card  Primary">Primary</button>
                        <button class="dds__button dds__button--secondary dds__button--sm dds__card__footer__item"
                            type="button" aria-describedby="card  Secondary">
                            Secondary
                        </button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<style scoped>
.smallIcons {
    width: 48px;
    margin-bottom: 3%;
}

.container {
    padding-top: 5%;
    padding-left: 20%;
    display: flex;
    flex-direction: column;
}

h2 {
    color: #0063B8;
    
}
.teste{
    padding-bottom: 3%;
    display: flex;
    flex-direction:row;
    justify-content: space-between;
}
.dds__card__media{
}
button{
    white-space: nowrap;
}
</style>
<script lang="ts">
</script>