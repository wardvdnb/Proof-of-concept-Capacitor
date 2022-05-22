<template>
    <div id="add-ticket">
        <h2>Add a New Ticket</h2>
        <form v-if="!submitted">
            <label>Ticket Title:</label>
            <input type="text" v-model.lazy="ticket.title" required />
            <label>Ticket Content:</label>
            <textarea v-model.lazy.trim="ticket.content"></textarea>
            <div id="checkboxes">
                <p>Ticket Categories:</p>
                <label>Remote</label>
                <input type="checkbox" value="remote" v-model="ticket.categories" />
                <label>Onsite</label>
                <input type="checkbox" value="onsite" v-model="ticket.categories" />
            </div>
            <label>Author:</label>
            <select v-model="ticket.author">
                <!-- <option v-for="author in authors">{{ author }}</option> -->
            </select>
            <hr />
            <b-button variant="primary" v-on:click.prevent="post">Add Ticket</b-button>
        </form>
        <div v-if="submitted">
            <h3>Thanks for adding your post</h3>
        </div>
    </div>
</template>

<script>
// Imports
import axios from 'axios';

export default {
    data () {
        return {
            ticket: {
                title: '',
                content: '',
                categories: [],
                author: ''
            },
            authors: ['The Net Ninja', 'The Angular Avenger', 'The Vue Vindicator'],
            submitted: false
        }
    },
    methods: {
        post: function(){
            this.$http.post('https://nn-vue-playlist.firebaseio.com/posts.json', this.ticket).then(function(data){
                console.log(data);
                this.submitted = true;
            });
        }
    },
    created(){
        axios.get('https://localhost:5001/api/Tickets').then(
            function(data){
            console.log(data.data);
        });
    }
}
</script>

<style scoped>
#add-ticket *{
    box-sizing: border-box;
}
#add-ticket{
    margin: 20px auto;
    max-width: 600px;
    padding: 20px;
}
label{
    display: block;
    margin: 20px 0 10px;
}
input[type="text"], textarea, select{
    display: block;
    width: 100%;
    padding: 8px;
}
textarea{
    height:200px;
}
#preview{
    padding: 10px 20px;
    border: 1px dotted #ccc;
    margin: 30px 0;
}
h3{
    margin-top: 10px;
}
#checkboxes input{
    display: inline-block;
    margin-right: 10px;
}
#checkboxes label{
    display: inline-block;
    margin-top: 0;
}
hr{
    display: none;
}

button{
    display: block;
    margin: 20px 0;
    border: 0;
    padding: 12px;
    border-radius: 4px;
    font-size: 18px;
    cursor: pointer;
}
</style>
