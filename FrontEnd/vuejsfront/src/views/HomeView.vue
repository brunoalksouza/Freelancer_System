<template>
  <div class="home">
    <h1>Proposal Cards</h1>
    <div class="proposal-cards-container">
      <ProposalCard
        v-for="proposal in proposals"
        :key="proposal.id"
        v-bind="proposal"
        @view-more="handleViewMore(proposal.id)"
      />
    </div>
  </div>
</template>

<script>
import ProposalCard from "@/components/ProposalCard.vue";

export default {
  name: "HomeView",
  components: {
    ProposalCard,
  },
  data() {
    return {
      proposals: [
        {
          id: 1,
          clientName: "John Doe",
          clientAvatar: "https://via.placeholder.com/91",
          ratingImage: "https://via.placeholder.com/93x14",
          status: "Active",
          serviceTitle: "Web Development",
          servicePrice: 100.0,
          serviceDateTime: "2023-04-15 14:00",
          serviceCategory: "IT Services",
          description:
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut blandit ullamcorper bibendum....",
          calendarIcon: "https://via.placeholder.com/17",
          categoryIcon: "https://via.placeholder.com/17",
        },
        {
          id: 2,
          clientName: "Jane Smith",
          clientAvatar: "https://via.placeholder.com/91",
          ratingImage: "https://via.placeholder.com/93x14",
          status: "Pending",
          serviceTitle: "Graphic Design",
          servicePrice: 80.0,
          serviceDateTime: "2023-04-20 10:00",
          serviceCategory: "Design",
          description:
            "Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam....",
          calendarIcon: "https://via.placeholder.com/17",
          categoryIcon: "https://via.placeholder.com/17",
        },
      ],
    };
  },
  methods: {
    handleViewMore(id) {
      console.log(`View more clicked for proposal ${id}`);
      // Implement view more functionality here
    },
  },
};
</script>

<style scoped>
.home {
  max-width: 1200px;
  margin: 0 auto;
  padding: 20px;
}

h1 {
  text-align: center;
  margin-bottom: 30px;
}

.proposal-cards-container {
  display: flex;
  flex-wrap: wrap;
  gap: 20px;
  justify-content: center;
}
</style>
