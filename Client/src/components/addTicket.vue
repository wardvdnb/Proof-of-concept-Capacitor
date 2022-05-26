<template>
    <div id="add-ticket">
        <h2>Add a New Ticket</h2>
        <div>
            <b-form @submit="onSubmit" @reset="onReset" v-if="show" enctype="multipart/form-data">
                <b-form-group id="input-group-1" class="mb-2" label="Title:" label-for="input-1">
                    <b-form-input
                    id="input-1"
                    v-model="form.title"
                    placeholder="Enter a title"
                    required
                    ></b-form-input>
                </b-form-group>

                <b-form-group id="input-group-2" class="mb-2" label="Description:" label-for="input-2">
                    <b-form-textarea
                    id="input-2"
                    v-model="form.description"
                    placeholder="Enter a description"
                    required
                    ></b-form-textarea>
                </b-form-group>

                <b-form-group id="input-group-3" class="mb-3" label="Engineer:" label-for="input-3">
                    <b-form-select
                    id="input-3"
                    v-model="form.engineer"
                    :options="engineers"
                    required
                    ></b-form-select>
                </b-form-group>

                <b-button id="submitBtn" type="submit" class="d-inline mr-1 p-2" variant="primary">Submit</b-button>
                <b-button type="reset" class="d-inline ml-1 p-2" variant="danger">Reset</b-button>
            </b-form>
        </div>
    </div>
</template>

<script>
// Imports
import axios from 'axios';

export default {
    data () {
        return {
            form: {
                title: '',
                description: '',
                engineer: null,
            },
            engineers: [],
            submitted: false,
            show: true
        }
    },
    methods: {
        onSubmit(event) {
            event.preventDefault()
            axios.post(`${process.env.VUE_APP_API}/Tickets`, this.form).then(
                () => this.$router.push('/')
            );
        },
        onReset(event) {
            event.preventDefault()
            this.form.title = ''
            this.form.description = ''
            this.form.engineer = null
            // Trick to reset/clear native browser form validation state
            this.show = false
            this.$nextTick(() => {
            this.show = true
            })
        },
    },
    created(){
        axios.get(`${process.env.VUE_APP_API}/Engineer`).then(
            data => {
                let engineers = data.data;
                this.engineers = [
                    { text: 'Select One', value: null }, 
                    ...engineers.map(engineer => 
                    ({ 
                        text: `${engineer.firstName} ${engineer.lastName}`, 
                        value: ([{firstName: engineer.firstName,
                                lastName: engineer.lastName,
                                email: engineer.email,
                                tickets: engineer.tickets}])
                    }))
                ];
            }
        );
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
#submitBtn{
    margin-right: 0.5em;
}
label{
    display: block;
    margin: 20px 0 10px;
}
input[type="text"], textarea, select{
    display: block;
    width: 100%;
    padding: 6px;
}
</style>
