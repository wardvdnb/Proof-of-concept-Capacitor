<template>
    <div id="single-ticket">
        <b-card
                border-variant="dark"
                :header="ticket.title"
                :sub-title="`Engineer: ${ticket.engineer.firstName} ${ticket.engineer.lastName}`"
                header-bg-variant="dark"
                header-text-variant="white"
                align="center"
                class="m-4"
            >

                <b-card-text>
                    <b>Created:</b> {{ticket.created | formatDate}}
                </b-card-text>
                <b-card-text>
                    <b>Description:</b> {{ticket.description}}
                </b-card-text>
            </b-card>
    </div>
</template>

<script>
// Imports
import { Http } from '@capacitor-community/http';

export default {
    data () {
        return {
            id: this.$route.params.id,
            ticket: {}
        }
    },
    created() {
        Http.request({
            method: 'GET',
            url: `${process.env.VUE_APP_API}/Tickets/${this.id}`,
        })
        .then(({ data }) => {
            this.ticket = data;
        })
    }
}
</script>

<style>
</style>
