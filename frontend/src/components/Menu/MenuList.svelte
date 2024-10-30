<script lang="ts">
    import ProjectCard from './ProjectCard.svelte';
    import AddNewCard from './AddNewCard.svelte';

    export let list;
</script>

<div class="space-y-3 rounded-lg bg-gray-200/75 p-3.5 dark:bg-gray-700/75">
    <div class="flex items-center justify-between">
        <h3 class="font-semibold">{list.title}</h3>
        <button
                type="button"
                class="inline-flex items-center justify-center gap-1 rounded-lg border border-transparent px-3 py-2 text-sm font-semibold leading-5 text-gray-800 hover:border-gray-300 hover:text-gray-900 hover:shadow-sm focus:ring focus:ring-gray-300/25 active:border-gray-200 active:shadow-none dark:text-gray-300 dark:hover:border-gray-600 dark:hover:text-gray-200 dark:focus:ring-gray-600/40 dark:active:border-gray-700"
        >
            <svg
                    class="hi-mini hi-ellipsis-horizontal -mx-1 inline-block size-4 opacity-50"
                    xmlns="http://www.w3.org/2000/svg"
                    viewBox="0 0 20 20"
                    fill="currentColor"
                    aria-hidden="true"
            >
                <path
                        d="M3 10a1.5 1.5 0 113 0 1.5 1.5 0 01-3 0zM8.5 10a1.5 1.5 0 113 0 1.5 1.5 0 01-3 0zM15.5 8.5a1.5 1.5 0 100 3 1.5 1.5 0 000-3z"
                />
            </svg>
        </button>
    </div>
    <div class="space-y-3">
        {#each list.cards as card}
            <ProjectCard {card} color={list.color} />
        {/each}
        <AddNewCard />
    </div>
</div>