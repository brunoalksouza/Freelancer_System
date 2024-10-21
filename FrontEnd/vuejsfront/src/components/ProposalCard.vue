<template>
  <article class="proposal-card">
    <div class="proposal-card__content">
      <div class="proposal-card__columns">
        <div class="proposal-card__avatar-column">
          <img
            :src="clientAvatar"
            class="proposal-card__avatar"
            :alt="`${clientName}'s avatar`"
          />
        </div>
        <div class="proposal-card__details-column">
          <div class="proposal-card__header">
            <div class="proposal-card__client-info">
              <h2 class="proposal-card__client-name">{{ clientName }}</h2>
              <img
                :src="ratingImage"
                class="proposal-card__rating"
                alt="Client rating"
              />
            </div>
            <span class="proposal-card__status">{{ status }}</span>
          </div>
          <hr class="proposal-card__divider" />
          <div class="proposal-card__proposal-info">
            <div class="proposal-card__proposal-details">
              <h3 class="proposal-card__proposal-title">
                {{ serviceTitle }} - R$ {{ servicePrice }}
              </h3>
              <div class="proposal-card__proposal-date">
                <img
                  :src="calendarIcon"
                  class="proposal-card__calendar-icon"
                  alt="Calendar icon"
                />
                <span class="proposal-card__date-time">{{
                  serviceDateTime
                }}</span>
              </div>
            </div>
            <div class="proposal-card__proposal-category">
              <img
                :src="categoryIcon"
                class="proposal-card__category-icon"
                alt="Category icon"
              />
              <span>{{ serviceCategory }}</span>
            </div>
          </div>
          <p class="proposal-card__description">
            {{ description }}
          </p>
          <button class="proposal-card__cta" @click="viewMore">VER MAIS</button>
        </div>
      </div>
    </div>
  </article>
</template>

<script>
export default {
  name: "ProposalCard",
  props: {
    clientName: String,
    clientAvatar: String,
    ratingImage: String,
    status: String,
    serviceTitle: String,
    servicePrice: Number,
    serviceDateTime: String,
    serviceCategory: String,
    description: String,
    calendarIcon: String,
    categoryIcon: String,
  },
  methods: {
    viewMore() {
      // Implement view more functionality
      this.$emit("view-more");
    },
  },
};
</script>

<style scoped>
.proposal-card {
  max-width: 592px;
  border-radius: 23px;
  background-color: #fff;
  box-shadow: 0 4px 4px rgba(0, 0, 0, 0.25);
  border: 1px solid #000;
  padding: 18px 26px 18px 10px;
  font-family: Inter, sans-serif;
  color: #000;
}

.proposal-card__content {
  width: 100%;
}

.proposal-card__columns {
  display: flex;
  gap: 20px;
}

.proposal-card__avatar-column {
  width: 17%;
}

.proposal-card__avatar {
  aspect-ratio: 1;
  object-fit: contain;
  width: 91px;
  border-radius: 110px;
  align-self: stretch;
  margin: auto 0;
}

.proposal-card__details-column {
  width: 83%;
}

.proposal-card__header {
  display: flex;
  align-items: flex-start;
  justify-content: space-between;
  font-weight: 700;
}

.proposal-card__client-name {
  font-size: 18px;
  margin: 0;
}

.proposal-card__rating {
  aspect-ratio: 6.62;
  object-fit: contain;
  width: 93px;
  margin-top: 15px;
}

.proposal-card__status {
  border-radius: 19px;
  background-color: #fff;
  font-size: 14px;
  padding: 8px 39px;
  border: 1px solid #000;
}

.proposal-card__divider {
  margin: 15px 0;
  border: none;
  border-top: 1px solid #000;
}

.proposal-card__proposal-info {
  display: flex;
  justify-content: space-between;
}

.proposal-card__proposal-title {
  font-size: 14px;
  font-weight: 700;
  margin: 0 0 10px;
}

.proposal-card__proposal-date,
.proposal-card__proposal-category {
  display: flex;
  align-items: center;
  gap: 7px;
  font-size: 10px;
  font-weight: 400;
}

.proposal-card__calendar-icon,
.proposal-card__category-icon {
  width: 17px;
  object-fit: contain;
}

.proposal-card__description {
  text-align: left;
  font-size: 15px;
  font-weight: 400;
  margin: 15px 0px 0px 0;
}

.proposal-card__cta {
  border-radius: 26px;
  background-color: #000;
  color: #fff;
  font-size: 13px;
  font-weight: 700;
  padding: 11px 36px;
  border: none;
  cursor: pointer;
  float: right;
}

@media (max-width: 991px) {
  .proposal-card {
    padding-right: 20px;
  }

  .proposal-card__columns {
    flex-direction: column;
  }

  .proposal-card__avatar-column,
  .proposal-card__details-column {
    width: 100%;
  }

  .proposal-card__avatar {
    margin-top: 40px;
  }

  .proposal-card__details-column {
    margin-top: 35px;
  }

  .proposal-card__status {
    padding: 8px 20px;
  }

  .proposal-card__description {
    margin-right: 10px;
  }

  .proposal-card__cta {
    padding: 11px 20px;
  }
}
</style>
