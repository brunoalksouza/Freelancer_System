<template>
  <div class="login-container">
    <header class="login-header">
      <h1 class="visually-hidden">Login Page</h1>
    </header>
    <main class="login-content">
      <section class="image-section">
        <img
          loading="lazy"
          :src="
            require('@/assets/LoginView/95cd3ebe39f8704f12ee14178415e50d18f28074f59c83ce8ea6fe5f9c84cef1.png')
          "
          alt="Login illustration"
          class="login-image"
        />
      </section>
      <section class="form-section">
        <form @submit.prevent="handleSubmit" class="login-form">
          <h2 class="form-title">LOGIN</h2>
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
          <div class="form-links">
            <a href="#" @click.prevent="createAccount" class="form-link"
              >Criar conta!</a
            >
            <a href="#" @click.prevent="forgotPassword" class="form-link"
              >Esqueci minha senha</a
            >
          </div>
          <button type="submit" class="submit-button">ENTRAR</button>
        </form>
      </section>
    </main>
  </div>
</template>

<script>
import InputField from "@/components/InputField.vue";

export default {
  components: {
    InputField,
  },
  data() {
    return {
      email: "",
      password: "",
    };
  },
  methods: {
    handleSubmit() {
      console.log("Email:", this.email, "Senha:", this.password);
    },
    createAccount() {
      console.log("Criar conta clicado");
    },
    forgotPassword() {
      console.log("Esqueci minha senha clicado");
    },
  },
};
</script>

<style scoped>
.login-container {
  background-color: #fff;
  padding: 0 20px; /* Reduzi o padding para telas maiores */
  overflow: hidden;
  max-width: 100vw; /* Garante que o container nunca ultrapasse 100% da largura da tela */
  box-sizing: border-box;
}

body {
  margin: 0;
  padding: 0;
  overflow-x: hidden; /* Evita rolagem horizontal no body */
}

.login-content {
  display: flex;
  flex-wrap: wrap; /* Permite que as seções se ajustem nas telas pequenas */
  justify-content: center;
}

.image-section {
  width: 61%;
  max-width: 100%; /* Garante que a imagem nunca ultrapasse a largura do container */
}

.login-image {
  aspect-ratio: 0.8;
  object-fit: contain;
  object-position: center;
  width: 100dvh;
  max-width: 100dvh;
  height: 100dvh;
  max-height: 100dvh;
}

.form-section {
  width: 39%;
  max-width: 100%;
  padding: 0 10px; /* Reduz o padding lateral */
}

.login-form {
  border-radius: 15px;
  background-color: #fff;
  display: flex;
  flex-direction: column;
  color: #000;
  padding: 32px 20px 110px; /* Ajuste o padding para responsividade */
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

.form-links {
  display: flex;
  justify-content: space-between;
  font-size: 18px;
  margin-bottom: 50px;
}

.form-link {
  color: #000;
  text-decoration: none;
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
}

.visually-hidden {
  position: absolute;
  width: 1px;
  height: 1px;
  padding: 0;
  margin: -1px;
  overflow: hidden;
  clip: rect(0, 0, 0, 0);
  white-space: nowrap;
  border: 0;
}

@media (max-width: 991px) {
  .login-container {
    padding-right: 20px;
  }

  .login-content {
    flex-direction: column;
  }

  .image-section,
  .form-section {
    width: 100%;
  }

  .login-image {
    max-width: 100%;
    margin-top: 40px;
  }

  .login-form {
    max-width: 100%;
    margin-top: 40px;
    padding: 0 20px 100px;
  }

  .submit-button {
    white-space: normal;
    padding: 21px 20px;
  }
}

@media (max-width: 768px) {
  .login-form {
    padding: 0 10px 50px; /* Ajuste menor de padding para telas menores */
  }

  .submit-button {
    padding: 16px 10px; /* Botão mais compacto para telas pequenas */
  }

  .form-links {
    flex-direction: column;
    align-items: center;
  }

  .form-link {
    margin-bottom: 10px;
  }
}
</style>
