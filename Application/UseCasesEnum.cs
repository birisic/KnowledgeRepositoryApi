﻿namespace Application
{
    public enum UseCasesEnum
    {
        UserRegistration = 1,
        WorkspaceDeletion = 2, //delete workspace
        WorkspaceRetrieval = 3, //read workspace
        WorkspaceCreation = 4, //create workspace
        WorkspaceModification = 5, //update document contents, or any workspace's owner or parent
    }
}
