export default {
    computed: {
        filteredTickets: function(){
            return this.tickets.filter((ticket) => {
                return ticket.title.match(this.search);
            });
        }
    }
};
