<template>
  <div class="register-container">
    <header class="register-header">
      <h1 class="visually-hidden">Register Page</h1>
    </header>
    <main class="register-content">
      <section class="form-section">
        <form @submit.prevent="handleRegister" class="register-form">
          <h2 class="form-title">CADASTRAR</h2>
          <div class="form-group">
            <InputField
              id="name"
              type="text"
              label="Nome:"
              placeholder="Nome"
              v-model="name"
            />
          </div>
          <div class="form-group">
            <InputField
              id="email"
              type="email"
              label="Email:"
              placeholder="Email"
              v-model="email"
            />
          </div>
          <div class="form-group">
            <InputField
              id="password"
              type="password"
              label="Senha:"
              placeholder="Senha"
              v-model="password"
            />
          </div>
          <div class="form-group">
            <InputField
              id="confirm-password"
              type="password"
              label="Confirmar Senha:"
              placeholder="Confirmar Senha"
              v-model="confirmPassword"
            />
          </div>
          <div class="form-group">
            <InputField
              id="objective"
              type="text"
              label="Objetivo:"
              placeholder="Técnico ou Cliente"
              v-model="objective"
            />
          </div>
          <p class="login-link" @click.prevent="goToLogin">Já possuo uma conta</p>
          <button type="submit" class="submit-button">CADASTRAR</button>
        </form>
      </section>
      <section class="image-section">
        <img
          loading="lazy"
          src="https://cdn.builder.io/api/v1/image/assets/TEMP/e0a6fb5495996e6c33e8bab1a59db9b7766eab09b776ea498c470ded3288bddb?placeholderIfAbsent=true&apiKey=dda130aa61fe498cb209bd67829a0c98"
          alt="Registration illustration"
          class="registration-image"
        />
      </section>
    </main>
  </div>
</template>

<script>
import InputField from '@/components/InputField.vue';

export default {
  components: {
    InputField,
  },
  data() {
    return {
      name: '',
      email: '',
      password: '',
      confirmPassword: '',
      objective: '',
    };
  },
  methods: {
    handleRegister() {
      console.log('Registro submetido:', this.name, this.email, this.password, this.confirmPassword, this.objective);
    },
    goToLogin() {
      console.log('Redirecionando para login');
    },
  },
};
</script>

<style scoped>
.registration-container {
  background-color: #fff;
  padding: 0 51px;
  overflow: hidden;
}

.registration-content {
  display: flex;
  gap: 20px;
}

.form-section {
  width: 39%;
}

.registration-form {
  border-radius: 15px;
  background-color: #fff;
  display: flex;
  flex-direction: column;
  color: #000;
  padding: 36px 56px;
  font: 400 22px Inter, sans-serif;
}

.form-title {
  font-size: 35px;
  font-weight: 700;
  text-align: center;
  margin-bottom: 19px;
}

.form-group {
  margin-bottom: 29px;
}

.login-link {
  font-size: 18px;
  margin-top: 12px;
  text-align: center;
  cursor: pointer;
  color: #000;
}

.submit-button {
  border-radius: 32px;
  background-color: #272343;
  font-size: 18px;
  color: #fff;
  font-weight: 700;
  padding: 21px 70px;
  border: none;
  cursor: pointer;
  align-self: center;
}

.image-section {
  width: 61%;
}

.registration-image {
  aspect-ratio: 0.8;
  object-fit: contain;
  object-position: center;
  width: 100%;
}

@media (max-width: 991px) {
  .registration-container {
    padding-left: 20px;
  }

  .registration-content {
    flex-direction: column;
    align-items: stretch;
    gap: 0;
  }

  .form-section,
  .image-section {
    width: 100%;
  }

  .registration-form {
    padding: 0 20px;
  }

  .submit-button {
    padding: 21px 20px;
    white-space: normal;
  }

  .registration-image {
    max-width: 100%;
    margin-top: 40px;
  }
}
</style>
