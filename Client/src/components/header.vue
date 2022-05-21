<template>
    <b-navbar class="px-5 py-3" toggleable="lg" type="dark" variant="dark">
        <b-navbar-brand to="/">Timedesk</b-navbar-brand>
        <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>
        <b-collapse id="nav-collapse" is-nav>
            <b-navbar-nav class="ml-5">
                <b-nav-item to="/" exact>Tickets</b-nav-item>
                <b-nav-item to="/add" exact>Add a new ticket</b-nav-item>
            </b-navbar-nav>
        </b-collapse>
    </b-navbar>
    <!-- <nav class="background: primary">
        <ul>
            <li><router-link to="/" exact>Ticket</router-link></li>
            <li><router-link to="/add" exact>Add a new ticket</router-link></li>
        </ul>
    </nav> -->
</template>

<script>
export default {}
</script>

<style scoped>
li{
    display: inline-block;
    margin: 0 5px;
}
/* a{
    padding: 8px;
    border-radius: 5px;
} */
nav{
    padding: 30px 0;
    margin-bottom: 40px;
}
/* .router-link-active{
    background: rgba(75, 75, 75, 0.8);
} */
</style>
