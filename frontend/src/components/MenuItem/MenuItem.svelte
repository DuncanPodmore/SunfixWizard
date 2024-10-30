<script lang="ts">
  export let name = "";
  export let link = "";
  export let onClick = async () => {};

  // Define a function to handle both the onClick and navigation
  const handleClick = async (event: any) => {
    event.preventDefault(); // Prevent default anchor behavior
    await onClick(); // Execute the passed onClick function
    window.location.href = link; // Navigate to the provided link
  };
</script>

<a
  href={link}
  on:click={handleClick}
  class="group flex items-center space-x-2 rounded-lg border border-transparent px-2.5 text-sm font-medium text-gray-800 hover:bg-indigo-50 hover:text-gray-900 active:border-indigo-100 dark:text-gray-200 dark:hover:bg-gray-700/75 dark:hover:text-white dark:active:border-gray-600"
>
  <span class="grow py-2">{name}</span>
</a>
