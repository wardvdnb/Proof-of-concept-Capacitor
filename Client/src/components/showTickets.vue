<template>
    <div id="show-tickets" class="px-3 mb-4">
        <h1>All Tickets</h1>
        <input type="text" v-model="search" placeholder="search tickets" />
        
        <div :key="ticket.id" v-for="ticket in filteredTickets" class="single-ticket">
            
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
                    <b>Created:</b> {{ticket.created | formatDate}}
                </b-card-text>
                <b-card-text>
                    <b>Description:</b> {{ticket.description}}
                </b-card-text>
                <b-link class="card-link" :to="'/ticket/' + ticket.id">View Ticket</b-link>
            </b-card>
        </div>
    </div >
</template>

<script>
// Imports
import searchMixin from '../mixins/searchMixin';
import axios from 'axios';

export default {
    data () {
        return {
            tickets: [],
            search: ''
        }
    },
    created() {
        axios.get(`${process.env.VUE_APP_API}/Tickets`).then(
            data => {this.tickets = data.data;}
        );
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
