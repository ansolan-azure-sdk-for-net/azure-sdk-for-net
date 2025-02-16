// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Storage.Models;

namespace Azure.ResourceManager.Storage
{
    /// <summary> A class representing collection of Table and their operations over a TableService. </summary>
    public partial class TableCollection : ArmCollection, IEnumerable<Table>, IAsyncEnumerable<Table>
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly TableRestOperations _restClient;

        /// <summary> Initializes a new instance of the <see cref="TableCollection"/> class for mocking. </summary>
        protected TableCollection()
        {
        }

        /// <summary> Initializes a new instance of TableCollection class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal TableCollection(ArmResource parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _restClient = new TableRestOperations(_clientDiagnostics, Pipeline, ClientOptions, Id.SubscriptionId, BaseUri);
        }

        IEnumerator<Table> IEnumerable<Table>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<Table> IAsyncEnumerable<Table>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => TableService.ResourceType;

        // Collection level operations.

        /// <summary> Creates a new table with the specified table name, under the specified account. </summary>
        /// <param name="tableName"> A table name must be unique within a storage account and must be between 3 and 63 characters.The name must comprise of only alphanumeric characters and it cannot begin with a numeric character. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tableName"/> is null. </exception>
        public virtual TableCreateOperation CreateOrUpdate(string tableName, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (tableName == null)
            {
                throw new ArgumentNullException(nameof(tableName));
            }

            using var scope = _clientDiagnostics.CreateScope("TableCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _restClient.Create(Id.ResourceGroupName, Id.Parent.Name, Id.Name, tableName, cancellationToken);
                var operation = new TableCreateOperation(Parent, response);
                if (waitForCompletion)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Creates a new table with the specified table name, under the specified account. </summary>
        /// <param name="tableName"> A table name must be unique within a storage account and must be between 3 and 63 characters.The name must comprise of only alphanumeric characters and it cannot begin with a numeric character. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tableName"/> is null. </exception>
        public async virtual Task<TableCreateOperation> CreateOrUpdateAsync(string tableName, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (tableName == null)
            {
                throw new ArgumentNullException(nameof(tableName));
            }

            using var scope = _clientDiagnostics.CreateScope("TableCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _restClient.CreateAsync(Id.ResourceGroupName, Id.Parent.Name, Id.Name, tableName, cancellationToken).ConfigureAwait(false);
                var operation = new TableCreateOperation(Parent, response);
                if (waitForCompletion)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="tableName"> A table name must be unique within a storage account and must be between 3 and 63 characters.The name must comprise of only alphanumeric characters and it cannot begin with a numeric character. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<Table> Get(string tableName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("TableCollection.Get");
            scope.Start();
            try
            {
                if (tableName == null)
                {
                    throw new ArgumentNullException(nameof(tableName));
                }

                var response = _restClient.Get(Id.ResourceGroupName, Id.Parent.Name, Id.Name, tableName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new Table(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="tableName"> A table name must be unique within a storage account and must be between 3 and 63 characters.The name must comprise of only alphanumeric characters and it cannot begin with a numeric character. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<Table>> GetAsync(string tableName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("TableCollection.Get");
            scope.Start();
            try
            {
                if (tableName == null)
                {
                    throw new ArgumentNullException(nameof(tableName));
                }

                var response = await _restClient.GetAsync(Id.ResourceGroupName, Id.Parent.Name, Id.Name, tableName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new Table(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="tableName"> A table name must be unique within a storage account and must be between 3 and 63 characters.The name must comprise of only alphanumeric characters and it cannot begin with a numeric character. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<Table> GetIfExists(string tableName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("TableCollection.GetIfExists");
            scope.Start();
            try
            {
                if (tableName == null)
                {
                    throw new ArgumentNullException(nameof(tableName));
                }

                var response = _restClient.Get(Id.ResourceGroupName, Id.Parent.Name, Id.Name, tableName, cancellationToken: cancellationToken);
                return response.Value == null
                    ? Response.FromValue<Table>(null, response.GetRawResponse())
                    : Response.FromValue(new Table(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="tableName"> A table name must be unique within a storage account and must be between 3 and 63 characters.The name must comprise of only alphanumeric characters and it cannot begin with a numeric character. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<Table>> GetIfExistsAsync(string tableName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("TableCollection.GetIfExists");
            scope.Start();
            try
            {
                if (tableName == null)
                {
                    throw new ArgumentNullException(nameof(tableName));
                }

                var response = await _restClient.GetAsync(Id.ResourceGroupName, Id.Parent.Name, Id.Name, tableName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return response.Value == null
                    ? Response.FromValue<Table>(null, response.GetRawResponse())
                    : Response.FromValue(new Table(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="tableName"> A table name must be unique within a storage account and must be between 3 and 63 characters.The name must comprise of only alphanumeric characters and it cannot begin with a numeric character. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<bool> CheckIfExists(string tableName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("TableCollection.CheckIfExists");
            scope.Start();
            try
            {
                if (tableName == null)
                {
                    throw new ArgumentNullException(nameof(tableName));
                }

                var response = GetIfExists(tableName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="tableName"> A table name must be unique within a storage account and must be between 3 and 63 characters.The name must comprise of only alphanumeric characters and it cannot begin with a numeric character. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<bool>> CheckIfExistsAsync(string tableName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("TableCollection.CheckIfExists");
            scope.Start();
            try
            {
                if (tableName == null)
                {
                    throw new ArgumentNullException(nameof(tableName));
                }

                var response = await GetIfExistsAsync(tableName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets a list of all the tables under the specified storage account. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="Table" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<Table> GetAll(CancellationToken cancellationToken = default)
        {
            Page<Table> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("TableCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _restClient.GetAll(Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new Table(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<Table> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("TableCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _restClient.GetAllNextPage(nextLink, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new Table(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Gets a list of all the tables under the specified storage account. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="Table" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<Table> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<Table>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("TableCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _restClient.GetAllAsync(Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new Table(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<Table>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("TableCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _restClient.GetAllNextPageAsync(nextLink, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new Table(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        // Builders.
        // public ArmBuilder<ResourceIdentifier, Table, TableData> Construct() { }
    }
}
