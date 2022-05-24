<template>
    <div id="show-tickets" class="px-3">
        <h1>All Tickets</h1>
        <input type="text" v-model="search" placeholder="search tickets" />
        
        <div :key="ticket.id" v-for="ticket in tickets" class="single-ticket">
            
            <b-card
                border-variant="dark"
                :header="ticket.title"
                :sub-title="`Engineer: ${ticket.engineer.firstName} ${ticket.engineer.lastName}`"
                header-bg-variant="dark"
                header-text-variant="white"
                align="center"
                class="mt-3"
            >

                <b-card-text>
                    Created: {{ticket.created | formatDate}}
                </b-card-text>
                <b-card-text>
                    Description: {{ticket.title}}
                </b-card-text>
                <b-link class="card-link" :to="'/ticket/' + ticket.id">View Ticket</b-link>
            </b-card>
        </div>
    </div>
</template>

<script>
// Imports
import searchMixin from '../mixins/searchMixin';
//import axios from 'axios';
//import '@capacitor-community/http';
//import { Plugins } from '@capacitor/core';
import { Http } from '@capacitor-community/http';

export default {
    data () {
        return {
            tickets: [],
            search: ''
        }
    },
    created() {
    //    axios.get('https://localhost:5001/api/Tickets').then(
    //         data => {
    //         var ticketsArray = data.data;
    //         // for (let ticket in data.data){
    //         //     console.log(ticket);
    //         //     ticketsArray.push(ticket);
    //         // }
    //         this.tickets = ticketsArray;
    //         console.log(this.tickets);
    //     });
        Http.request({
            method: 'GET',
            url: 'http://192.168.0.209:5001/api/Tickets',
        })
        .then(({ data }) => {
            this.tickets = data;
        })
    },
    mixins: [searchMixin]
}
</script>

<style scoped>
#show-tickets{
    max-width: 800px;
    margin: 0px auto;
}

#show-tickets a{
    text-decoration: none;
}

input[type="text"]{
    padding: 8px;
    width: 100%;
    box-sizing: border-box;
}

</style>
