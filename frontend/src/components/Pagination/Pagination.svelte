<script lang="ts">
    export let currentPage = 1;
    export let totalPages = 20;
    export let onPageChange = (page: number) => {
    };

    const handlePageChange = (page: number) => {
        if ((page > 0 && page <= totalPages)) {
            console.log(page);
            onPageChange(page);
        }
    };

    /**
     * Generates a subset of pages for pagination UI.
     *
     * @param totalPages - Total number of pages.
     * @param currentPage - The current active page.
     * @param visiblePages - Maximum number of pages to display in pagination.
     * @returns An array of pages to display, with '...' as separators where needed.
     */
    function getPagination(
        totalPages: number,
        currentPage: number,
        visiblePages: number = 5
    ): (number | "...")[] {
        const pages: (number | "...")[] = [];
        const half = Math.floor(visiblePages / 2);

        currentPage = Math.max(1, Math.min(currentPage, totalPages));

        let startPage = Math.max(1, currentPage - half);
        let endPage = startPage + visiblePages - 1;

        if (endPage > totalPages) {
            endPage = totalPages;
            startPage = Math.max(1, endPage - visiblePages + 1);
        }

        if (startPage > 1) {
            pages.push(1);
            if (startPage > 2) pages.push('...');
        }

        for (let i = startPage; i <= endPage; i++) {
            pages.push(i);
        }

        if (endPage < totalPages) {
            if (endPage < totalPages - 1) pages.push('...');
            pages.push(totalPages);
        }

        return pages;
    }


    // Example usage
    // console.log(getPagination(20, 1, 5));  // [1, 2, 3, 4, 5, "...", 20]
    // console.log(getPagination(20, 10, 5)); // [1, "...", 9, 10, 11, "...", 20]
    // console.log(getPagination(20, 19, 5)); // [1, "...", 17, 18, 19, 20]

</script>

<div class="text-center dark:text-gray-100">
    <div class="hidden sm:flex sm:items-center sm:justify-between">
        <div class="mr-2">
            Page <span class="font-semibold">{currentPage}</span> of <span class="font-semibold">{totalPages}</span>
        </div>

        <nav class="inline-flex">
            <button
                    class="pagination-button"
                    on:click={() => handlePageChange(currentPage - 1)}
                    disabled={currentPage === 1}
            >
                <svg
                        width={30}
                        class="hi-mini hi-chevron-left size-5"
                        style="color: #fff"
                        xmlns="http://www.w3.org/2000/svg"
                        viewBox="0 0 20 20"
                        fill="currentColor"
                >
                    <path
                            fill-rule="evenodd"
                            d="M12.79 5.23a.75.75 0 01-.02 1.06L8.832 10l3.938 3.71a.75.75 0 11-1.04 1.08l-4.5-4.25a.75.75 0 010-1.08l4.5-4.25a.75.75 0 011.06.02z"
                            clip-rule="evenodd"
                    />
                </svg>
            </button>

            {#each getPagination(totalPages, currentPage) as page}
                <button
                        class="pagination-button {page === currentPage ? 'active' : ''} -mr-px inline-flex items-center justify-center gap-2 border border-gray-200 px-4 py-2 font-semibold leading-6 text-gray-800 hover:z-1 hover:border-gray-300 hover:text-gray-900 hover:shadow-sm focus:z-1 focus:ring focus:ring-gray-300/25 active:z-1 active:border-gray-200 active:shadow-none dark:border-gray-700 dark:bg-gray-800 dark:text-gray-300 dark:hover:border-gray-600 dark:hover:text-gray-200 dark:focus:ring-gray-600/40 dark:active:border-gray-700"
                        on:click={() => {
                            if (page !== '...') {
                                handlePageChange(page)
                            }
                        }}
                >
                    {page}
                </button>
            {/each}

            <button
                    class="pagination-button"
                    on:click={() => handlePageChange(currentPage + 1)}
                    disabled={currentPage === totalPages}
            >
                <svg
                        width={30}
                        class="hi-mini hi-chevron-right size-5"
                        xmlns="http://www.w3.org/2000/svg"
                        viewBox="0 0 20 20"
                        fill="currentColor"
                >
                    <path
                            fill-rule="evenodd"
                            d="M7.21 14.77a.75.75 0 01.02-1.06L11.168 10 7.23 6.29a.75.75 0 111.04-1.08l4.5 4.25a.75.75 0 010 1.08l-4.5 4.25a.75.75 0 01-1.06-.02z"
                            clip-rule="evenodd"
                    />
                </svg>
            </button>
        </nav>
    </div>
</div>

<style>
    .pagination-button {
        border: 1px solid var(--border-color, #e2e8f0);
        border-color: rgb(55 65 81 / var(--tw-border-opacity));
        padding: 0.5rem 1rem;
        background-color: rgb(31 41 55 / var(--tw-bg-opacity));;
        font-weight: 600;
        cursor: pointer;
        transition: all 0.2s;
        color: rgb(209 213 219 / var(--tw-text-opacity));
    }

    .pagination-button.active {
        background-color: var(--bg-active-color, #374151bf);
    }

    .pagination-button:disabled {
        cursor: not-allowed;
        opacity: 0.5;
    }
</style>
