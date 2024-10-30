<script lang="ts">
    import {writable} from 'svelte/store';

    let searchQuery = '';
    const searchResults = writable<any>([]);

    // Function to fetch data from the API
    export let fetchData = async(query: string): Promise<any[] | null> => {return []}

    // Function to handle search query changes
    async function handleSearch(event: any) {
        searchQuery = event.target.value;
        searchResults.set(await fetchData(searchQuery));
    }

    // Function to handle item selection
    export let handleSelect = (item: any) =>{
        console.log('Selected item:', item);
        // You can add more logic here, e.g., setting a selected value or closing the dropdown
    }

    export let displayValue = (item: any) => item.name;

    export let title = 'Search';
</script>

<form class="space-y-6 dark:text-gray-100" on:submit={() => {}}>
    <div class="space-y-1">
        <label for="search" class="font-medium">{title}</label>
        <input
                type="text"
                id="search"
                name="search"
                placeholder="Enter search query"
                class="inline-flex items-center justify-center space-x-1 rounded-lg border border-gray-200 bg-white px-3 py-2 text-sm font-semibold leading-5 text-gray-800 hover:border-gray-300 hover:text-gray-900 hover:shadow-sm focus:ring focus:ring-gray-300 focus:ring-opacity-25 active:border-gray-200 active:shadow-none dark:border-gray-700 dark:bg-gray-800 dark:text-gray-300 dark:hover:border-gray-600 dark:hover:text-gray-200 dark:focus:ring-gray-600 dark:focus:ring-opacity-40 dark:active:border-gray-700"
                on:input={handleSearch}
        />
    </div>
    <div class="space-y-1">
        {#if $searchResults && $searchResults.length > 0}
            <ul class="rounded-lg border border-gray-200">
                {#each $searchResults as item (item.id)}
                    <li class="px-3 py-2 hover:bg-gray-100 cursor-pointer" on:click={() => handleSelect(item)}>
                        {displayValue(item)}
                    </li>
                {/each}
            </ul>
        {/if}
    </div>
</form>
