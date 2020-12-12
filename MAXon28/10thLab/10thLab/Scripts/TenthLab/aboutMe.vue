<template>
    <div id="animated-number-demo">
        <input v-model.number="number" type="number" step="20">
        <p>{{ animatedNumber }}</p>
    </div>

</template>
<script>
    export default {
        name: "about-component"
    };

    var vue = new Vue({
        el: '#animated-number-demo',
        data: {
            number: 40,
            tweenedNumber: 0
        },
        computed: {
            animatedNumber: function () {
                console.log("Топчик");
                return this.tweenedNumber.toFixed(0);
            }
        },
        watch: {
            number: function (newValue) {
                gsap.to(this.$data, { duration: 0.5, tweenedNumber: newValue });
            }
        }
    })
</script>