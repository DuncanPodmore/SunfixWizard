<script lang="ts">
    import {onMount} from "svelte";
    import type {Part} from "../../data/models";
    import Pagination from "../Pagination/Pagination.svelte";
    import PaginationCard from "../Pagination/PaginationCard.svelte";
    import EditPartModal from "../../routes/tool/parts/list/EditPartModal.svelte";
    import {del, get} from "../../data/apiService";

    let parts: Part[] = [];
    let current_page = 1;
    const page_length = 10;
    let partToEdit: Part | null = null;
    let editModalVisible: boolean = false;

    // Fetch parts data on mount
    onMount(async () => {
        await loadParts();
    });

    // Load parts from the API
    const loadParts = async () => {
        const data = await get<Part[]>("api/parts");
        if (data) {
            parts = data;
        } else {
            console.error("Failed to fetch parts");
        }
    };

    // Open the edit modal with a specific part or for a new part
    const editPart = (part: Part | null) => {
        partToEdit = part;
        editModalVisible = true;
    };

    // Handle deleting a part
    const deletePart = async (id: number) => {
        const result = await del<Part>(`api/parts`, id);
        if (result) {
            await loadParts(); // Reload parts after deletion
        } else {
            console.error("Failed to delete part");
        }
    };

    // Paginate parts
    function paginatedParts(ps: Part[], c_page: number) {
        const start = (c_page - 1) * page_length;
        const end = start + page_length;
        return ps.slice(start, end);
    }
</script>

<PaginationCard title="All Parts">
    <div class="mb-5 flex flex-col gap-3 text-center sm:flex-col sm:items-center sm:justify-between sm:text-left">
        <div class="w-full flex justify-between flex-row gap-3 text-center sm:flex-row sm:items-center sm:justify-between sm:text-left">
            <div>
                <h4 class="text-sm font-medium text-gray-500 dark:text-gray-400">
                    You have <span>{parts.length} parts</span>
                </h4>
            </div>
            <div class="flex items-center justify-center gap-2">
                <button
                        class="inline-flex items-center justify-center gap-2 rounded-lg border border-blue-700 bg-blue-700 px-4 py-2 font-semibold leading-6 text-white hover:border-blue-600 hover:bg-blue-600 hover:text-white focus:ring focus:ring-blue-400/50 active:border-blue-700 active:bg-blue-700 dark:focus:ring-blue-400/90"
                        on:click={() => editPart(null)}
                >
                    Add new part
                </button>
            </div>
        </div>

        <div class="min-w-full overflow-x-auto rounded border border-gray-200 bg-white dark:border-gray-700 dark:bg-gray-800">
            <table class="min-w-full whitespace-nowrap align-middle text-sm">
                <thead>
                <tr>
                    <th class="bg-gray-100/75 px-3 py-4 text-left font-semibold text-gray-900 dark:bg-gray-700/25 dark:text-gray-50">
                        Name
                    </th>
                    <th class="bg-gray-100/75 px-3 py-4 text-right font-semibold text-gray-900 dark:bg-gray-700/25 dark:text-gray-50">
                        Cost
                    </th>
                    <th class="bg-gray-100/75 px-3 py-4 text-center font-semibold text-gray-900 dark:bg-gray-700/25 dark:text-gray-50">
                        Actions
                    </th>
                </tr>
                </thead>
                <tbody>
                {#each paginatedParts(parts, current_page) as part}
                    <tr class="even:bg-gray-50 dark:even:bg-gray-900/50">
                        <td class="p-3">
                            <p class="font-medium">{part.name}</p>
                        </td>
                        <td class="p-3 text-right">R{part.price}</td>
                        <td class="p-3 text-center">
                            <button
                                    class="inline-flex items-center justify-center gap-2 rounded-lg border border-gray-200 bg-white px-2 py-1 text-sm font-semibold leading-5 text-gray-800 hover:border-gray-300 hover:text-gray-900 hover:shadow-sm focus:ring focus:ring-gray-300/25 active:border-gray-200 active:shadow-none dark:border-gray-700 dark:bg-gray-800 dark:text-gray-300 dark:hover:border-gray-600 dark:hover:text-gray-200 dark:focus:ring-gray-600/40 dark:active:border-gray-700"
                                    on:click={() => editPart(part)}
                            >
                                Edit
                            </button>
                            <button
                                    class="ml-2 inline-flex items-center justify-center gap-2 rounded-lg border border-red-700 bg-red-700 px-2 py-1 text-sm font-semibold leading-5 text-white hover:border-red-600 hover:bg-red-600 hover:text-white focus:ring focus:ring-red-400/50 active:border-red-700 active:bg-red-700 dark:focus:ring-red-400/90"
                                    on:click={() => deletePart(part.partId)}
                            >
                                Delete
                            </button>
                        </td>
                    </tr>
                {/each}
                </tbody>
            </table>
        </div>

        <div>
            <Pagination
                    currentPage={current_page}
                    totalPages={Math.ceil(parts.length / page_length)}
                    onPageChange={(page) => (current_page = page)}
            />
        </div>
    </div>
</PaginationCard>

{#if editModalVisible}
    <EditPartModal
            part={partToEdit}
            onDismiss={() => (editModalVisible = false)}
    />
{/if}
