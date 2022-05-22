<template>
    <div id="single-ticket">
        <h1>{{ ticket.title }}</h1>
        <article>{{ ticket.content }}</article>
        <p>Author: {{ ticket.author }}</p>
        <p>Categories:</p>
        <ul>
            <!-- <li v-for="category in ticket.categories">{{ category }}</li> -->
        </ul>
    </div>
</template>

<script>
// Imports

export default {
    data () {
        return {
            id: this.$route.params.id,
            ticket: {}
        }
    },
    created() {
        this.$http.get('https://nn-vue-playlist.firebaseio.com/posts/' + this.id + '.json').then(function(data){
            return data.json();
        }).then(function(data){
            this.ticket = data;
        });
    }
}
</script>

<style>
#single-ticket{
    max-width: 960px;
    margin: 0 auto;
    padding: 20px;
    background: #eee;
    border: 1px dotted #aaa;
}
</style>
