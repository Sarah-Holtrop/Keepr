<template>
    <div class="login">
        <form v-if="loginForm" @submit.prevent="loginUser">
            <input type="email" v-model="creds.email" placeholder="email">
            <input type="password" v-model="creds.password" placeholder="password">
            <button type="submit" class="btn btn-success">Login</button>
        </form>
        <form v-else @submit.prevent="register">
            <input type="text" v-model="newUser.username" placeholder="name">
            <input type="email" v-model="newUser.email" placeholder="email">
            <input type="password" v-model="newUser.password" placeholder="password">
            <button type="submit">Create Account</button>
        </form>
        <div @click="loginForm = !loginForm">
            <p v-if="loginForm">No account? Click to Register</p>
            <p v-else>Already have an account click to Login</p>
        </div>
        <div class="keeps">
            <HomeKeepsComponent></HomeKeepsComponent>
        </div>
    </div>
</template>

<script>
    import HomeKeepsComponent from '../components/HomeKeepsComponent.vue'

    export default {
        name: "login",
        data() {
            return {
                loginForm: true,
                creds: {
                    email: "",
                    password: ""
                },
                newUser: {
                    email: "",
                    password: "",
                    username: ""
                }
            };
        },
        beforeCreate() {
            if (this.$store.state.user.id) {
                this.$router.push({ name: "home" })
            }
        },
        methods: {
            register() {
                this.$store.dispatch("register", this.newUser);
            },
            loginUser() {
                this.$store.dispatch("login", this.creds);
            }
        },
        components: {
            HomeKeepsComponent
        }
    };
</script>

<style scoped>
    p {
        color: blue;

    }

    p:hover {
        color: lightblue;
        text-decoration: underline;
        cursor: pointer;

    }
</style>